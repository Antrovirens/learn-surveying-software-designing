using PIE.AxControls;
using PIE.Carto;
using PIE.Controls;
using PIE.Geometry;
using PIE.SystemUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIEAppication.Tool
{
    /// <summary>
    /// 拉框缩小工具类
    /// </summary>
    public class ZoomOutTool : BaseTool
    {
        #region 私有变量

        /// <summary>
        /// 地图实例
        /// </summary>
        private IMapControl m_MapControl;

        /// <summary>
        /// 制图实例
        /// </summary>
        private IPageLayoutControl m_PageLayoutControl;

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public ZoomOutTool()
        {
            base.Caption = "ZoomOutTool";
            base.Name = "ZoomOut";
            base.ToolTip = "拉框缩小";
        }

        /// <summary>
        /// 重写是否选中
        /// </summary>
        public override bool Checked
        {
            get
            {
                if (m_HookHelper.FocusMap == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                base.Checked = value;
            }
        }

        /// <summary>
        /// 重写鼠标down事件
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        public override void OnMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (m_HookHelper.ActiveView == null)
            {
                return;
            }
            //制图模式
            else if (m_HookHelper.Hook is IPageLayoutControl)
            {
                m_PageLayoutControl = m_HookHelper.Hook as IPageLayoutControl;
                //画的矩形Extent 
                IEnvelope trackExtent = m_PageLayoutControl.TrackRectangle();
                PIE.Geometry.IEnvelope currentExtent = m_PageLayoutControl.ActiveView.DisplayTransformation.VisibleBounds;
                double xMin, yMin, xMax, yMax;
                xMin = yMin = xMax = yMax = 0;
                m_PageLayoutControl.PageLayout.PageToMapPoint(m_HookHelper.FocusMap, trackExtent.XMin, trackExtent.YMin, ref xMin, ref yMin);
                m_PageLayoutControl.PageLayout.PageToMapPoint(m_HookHelper.FocusMap, trackExtent.XMax, trackExtent.YMax, ref xMax, ref yMax);

                IEnvelope extent = new Envelope();
                extent.PutCoords(xMin, yMin, xMax, yMax);
                //计算一个缩放比例
                double scale = currentExtent.GetWidth() * 1.00 / (trackExtent as IEnvelope).GetWidth();
                //缩放比例与地图模式下的基本一致
                extent.Expand(scale * 1.3, scale * 1.3, true);
                (m_PageLayoutControl.FocusMap as IActiveView).Extent = extent;
                (m_PageLayoutControl.FocusMap as IActiveView).PartialRefresh(ViewDrawPhaseType.ViewAll);

            }
            //地图模式
            else if (m_HookHelper.Hook is IMapControl)
            {
                m_MapControl = m_HookHelper.Hook as IMapControl;
                //画的矩形Extent 
                IEnvelope trackExtent = m_MapControl.TrackRectangle();
                if (trackExtent == null)
                {
                    return;
                }
                //获取当前的Extent
                IEnvelope currentExtent = m_MapControl.Extent;
                IEnvelope newExtent = null;
                //创建一个新的Extent
                double dWidth = currentExtent.GetWidth() * (currentExtent.GetWidth() / trackExtent.GetWidth());

                double dHeight = currentExtent.GetHeight() * (currentExtent.GetHeight() / trackExtent.GetHeight());

                double dXmin = currentExtent.XMin - ((trackExtent.XMin - currentExtent.XMin) * (currentExtent.GetWidth() / trackExtent.GetWidth()));

                double dYmin = currentExtent.YMin - ((trackExtent.YMin - currentExtent.YMin) * (currentExtent.GetHeight() / trackExtent.GetHeight()));

                double dXmax = (currentExtent.XMin - ((trackExtent.XMin - currentExtent.XMin) * (currentExtent.GetWidth() / trackExtent.GetWidth()))) + dWidth;

                double dYmax = (currentExtent.YMin - ((trackExtent.YMin - currentExtent.YMin) * (currentExtent.GetHeight() / trackExtent.GetHeight()))) + dHeight;

                //设置extent coordinate
                newExtent = new Envelope();
                newExtent.PutCoords(dXmin, dYmin, dXmax, dYmax);
                m_MapControl.Extent = newExtent;
                m_MapControl.PartialRefresh(ViewDrawPhaseType.ViewAll);
            }
        }
    }
}
