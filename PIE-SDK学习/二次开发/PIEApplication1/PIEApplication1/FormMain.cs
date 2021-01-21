using PIE.AxControls;
using PIE.Carto;
using PIE.Controls;
using PIE.DataSource;
using PIE.Display;
using PIE.Geometry;
using PIE.SystemUI;
using PIE.Plugin;
using PIEAppication.Command;
using PIEAppication.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PIEAppication
{
    /// <summary>
    ///PIE应用主窗体
    /// </summary>
    public partial class Frm_Main : Form
    {

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public Frm_Main()
        {
            InitializeComponent();
            //初始化加载
            InitFrm();
        }
        #endregion

        #region 文件pmd（事件）

        /// <summary>
        /// 新建地图
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_NewPwd_Click(object sender, EventArgs e)
        {
            NewPmd();
        }

        /// <summary>
        /// 打开地图
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_OpenPwd_Click(object sender, EventArgs e)
        {
            OpenPmd();
        }

        /// <summary>
        /// 保存地图工程
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_SavePwd_Click(object sender, EventArgs e)
        {
            SavePmd();
        }

        /// <summary>
        /// 另存地图工程
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_SaveasPwd_Click(object sender, EventArgs e)
        {
            SaveAsPmd();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出当前系统?", "退出", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_AddData_Click(object sender, EventArgs e)
        {
            ICommand cmd = new AddDataCommand();
            cmd.OnCreate(mapControl1);
            cmd.OnClick();
        }

        #endregion

        #region map、Page、Toc事件

        /// <summary>
        /// 地图模式鼠标移动事件
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void mapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            //设置屏幕坐标点
            int xScreen = e.Location.X;
            int yScreen = e.Location.Y;
            toolStripStatusLabel_screenCoordinate.Text = xScreen + "," + yScreen;
            string spatialReferenceName = string.Empty; ;
            IGeometry m_Geometry = mapControl1.FocusMap.ToMapPoint(e.Location) as IGeometry;
            ISpatialReference spatialReference = m_Geometry.SpatialReference;
            if (spatialReference != null)
            {
                spatialReferenceName = spatialReference.Name;
                //设置坐标系的名称
                toolStripStatusLabel_CoordinateInfo.Text = spatialReferenceName;
            }
            IPoint point = m_Geometry.Centroid();
            double x1, y1;
            x1 = y1 = 0;
            point.QueryCoords(ref x1, ref y1);
            x1 = Math.Round(x1, 4);
            y1 = Math.Round(y1, 4);
            //设置地图坐标点
            toolStripStatusLabel_coordinateSystem.Text = x1 + "," + y1;
        }

        /// <summary>
        /// 制图模式鼠标移动事件
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void pageLayoutControl1_MouseMove(object sender, MouseEventArgs e)
        {
            //设置屏幕坐标点
            int xScreen = e.Location.X;
            int yScreen = e.Location.Y;
            toolStripStatusLabel_screenCoordinate.Text = xScreen + "," + yScreen;
            string spatialReferenceName = string.Empty; ;
            IGeometry m_Geometry = mapControl1.FocusMap.ToMapPoint(e.Location) as IGeometry;
            ISpatialReference spatialReference = m_Geometry.SpatialReference;
            if (spatialReference != null)
            {
                spatialReferenceName = spatialReference.Name;
                //设置坐标系的名称
                toolStripStatusLabel_CoordinateInfo.Text = spatialReferenceName;
            }
            IPoint point = m_Geometry.Centroid();
            double x1, y1;
            x1 = y1 = 0;
            point.QueryCoords(ref x1, ref y1);
            x1 = Math.Round(x1, 4);
            y1 = Math.Round(y1, 4);
            //设置地图坐标点
            toolStripStatusLabel_coordinateSystem.Text = x1 + "," + y1;
        }

        /// <summary>
        /// 右键菜单事件
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void tocControlMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PIETOCNodeType type = PIETOCNodeType.Null;
                IMap map = null;
                ILayer layer = null;
                Object unk = Type.Missing;
                Object data = Type.Missing;
                tocControlMain.HitTest(e.X, e.Y, ref type, ref map, ref layer, ref unk, ref data);

                PIE.AxControls.PIETOCNodeTag tag = new PIETOCNodeTag();
                tag.Map = map;
                tag.Layer = layer;
                tag.UNK = unk;
                tag.Data = data;
                mapControl1.CustomerProperty = tag;

                switch (type)
                {
                    case PIETOCNodeType.FeatureLayer://矢量
                        IFeatureLayer featureLayer = layer as IFeatureLayer;
                        if (featureLayer == null) return;
                        this.contextMenuStrip_FeatureLayer.Show(tocControlMain, new System.Drawing.Point(e.X, e.Y)); //显示菜单
                        break;
                    case PIETOCNodeType.RasterLayer://栅格
                        IRasterLayer pRasterLayer = layer as IRasterLayer;
                        if (pRasterLayer == null)
                        {
                            return;
                        }
                        this.contextMenuStrip_FeatureLayer.Show(tocControlMain, new System.Drawing.Point(e.X, e.Y)); //显示菜单
                        break;
                    case PIETOCNodeType.Map://地图
                        this.contextMenuStrip_TocMenu.Show(tocControlMain, new System.Drawing.Point(e.X, e.Y)); //显示菜单
                        break;
                }
            }
        }

        /// <summary>
        /// tocMenuItem点击事件
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void tocMenuItem_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }
            ICommand command = item.Tag as ICommand;
            if (command == null)
            {
                return;
            }
            command.OnCreate(mapControl1); //必须加
            command.OnClick();
            ITool tool = command as ITool;
            if (tool != null)
            {
                mapControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 地图切换按钮
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0)
            {
                ActivateMapControl();
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                ActivatePageLayoutControl();
            }
        }

        /// <summary>
        /// mapcontrol鼠标UP事件
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void mapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip_MapControl.Show(mapControl1, new System.Drawing.Point(e.X, e.Y));
            }
        }

        /// <summary>
        /// mapControl菜单点击事件
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void mapControlMenuItem_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null) return;

            ICommand command = item.Tag as ICommand;
            if (command == null) return;
            command.OnCreate(mapControl1); //必须加
            command.OnClick();

            ITool tool = command as ITool;
            if (tool != null)
            {
                mapControl1.CurrentTool = tool;
            }
        }

        #endregion

        #region 地图操作

        /// <summary>
        /// 拉框放大
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_MapZoomIn_Click(object sender, EventArgs e)
        {
            ITool tool = new MapZoomInTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 拉框缩小
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_MapZoomOut_Click(object sender, EventArgs e)
        {
            ITool tool = new ZoomOutTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 居中放大
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_CenterZoomIn_Click(object sender, EventArgs e)
        {
            ICommand cmd = new CenterZoomInCommand();
            cmd.OnCreate(mapControl1);
            cmd.OnClick();
        }

        /// <summary>
        /// 居中缩小
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_CenterZoomOut_Click(object sender, EventArgs e)
        {
            ICommand cmd = new CenterZoomOutCommand();
            cmd.OnCreate(mapControl1);
            cmd.OnClick();
        }

        /// <summary>
        /// 漫游
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_PanTool_Click(object sender, EventArgs e)
        {
            ITool tool = new PanTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 全图显示
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_MapFullExtent_Click(object sender, EventArgs e)
        {
            ICommand cmd = new FullExtentCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
            }
            cmd.OnClick();
        }

        /// <summary>
        /// 1：1显示
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_MapNative_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ZoomToNativeCommand();
            cmd.OnCreate(mapControl1);
            cmd.OnClick();
        }

        /// <summary>
        /// 前一视图
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_PreviousView_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ZoomToPreviousExtentCommand();
            cmd.OnCreate(mapControl1);
            cmd.OnClick();
        }

        /// <summary>
        /// 后一视图
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_NextView_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ZoomToNextExtentCommand();
            cmd.OnCreate(mapControl1);
            cmd.OnClick();
        }

        /// <summary>
        /// 卷帘
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_SwipeLayer_Click(object sender, EventArgs e)
        {
            ITool tool = new SwipeLayerTool();
            ICommand cmd = tool as ICommand;
            cmd.OnCreate(mapControl1);
            mapControl1.CurrentTool = tool;
        }

        /// <summary>
        /// 探针工具
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_RasterIdentify_Click(object sender, EventArgs e)
        {
            ITool rIdentifyTool = new RasterIdentifyTool();
            ICommand cmd = rIdentifyTool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
                mapControl1.CurrentTool = rIdentifyTool;
            }
        }

        /// <summary>
        /// 属性查询
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_AttributeIdentify_Click(object sender, EventArgs e)
        {
            ITool attIdentifyTool = new AttributeIdentifyTool();
            ICommand cmd = attIdentifyTool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
                mapControl1.CurrentTool = attIdentifyTool;
            }
        }

        /// <summary>
        /// 空间量测
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_Measure_Click(object sender, EventArgs e)
        {
            ITool sMeasureCommand = new SpatialMeasureCommand();
            ICommand cmd = sMeasureCommand as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
                mapControl1.CurrentTool = sMeasureCommand;
            }
        }

        #endregion

        #region 制图操作

        /// <summary>
        /// 制图放大
        /// </summary>
        /// <param name="sender"> 事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_PageZoomIn_Click(object sender, EventArgs e)
        {
            ITool tool = new PageZoomInTool();
            ICommand cmd = tool as ICommand;
            cmd.OnCreate(pageLayoutControl1);
            pageLayoutControl1.CurrentTool = tool;
            pageLayoutControl1.PartialRefresh(ViewDrawPhaseType.ViewAll);
        }

        /// <summary>
        /// 制图缩小
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_PageZoomOut_Click(object sender, EventArgs e)
        {
            ITool tool = new PageZoomOutTool();
            ICommand cmd = tool as ICommand;
            cmd.OnCreate(pageLayoutControl1);
            pageLayoutControl1.CurrentTool = tool;
            pageLayoutControl1.PartialRefresh(ViewDrawPhaseType.ViewAll);
        }

        /// <summary>
        /// 制图平移
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_PagePan_Click(object sender, EventArgs e)
        {
            ITool tool = new PagePanTool();
            ICommand cmd = tool as ICommand;
            cmd.OnCreate(pageLayoutControl1);
            pageLayoutControl1.CurrentTool = tool;
            pageLayoutControl1.PartialRefresh(ViewDrawPhaseType.ViewAll);
        }

        /// <summary>
        /// 缩放至全图
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件发参数</param>
        private void toolStripButton_ZoomToWhole_Click(object sender, EventArgs e)
        {
            pageLayoutControl1.PageLayout.ZoomToWhole();
            pageLayoutControl1.PartialRefresh(ViewDrawPhaseType.ViewAll);
        }

        /// <summary>
        /// 缩放至100%
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_ZoomToOrigin_Click(object sender, EventArgs e)
        {
            pageLayoutControl1.PageLayout.ZoomToPercent(1.0);  //缩放到100%
            pageLayoutControl1.PartialRefresh(ViewDrawPhaseType.ViewAll);
        }

        /// <summary>
        /// 切换模板
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_SettingCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ChangePageTemplateCommand();
            cmd.OnCreate(pageLayoutControl1);
            cmd.OnClick();
        }

        #endregion

        #region 制图（事件）

        /// <summary>
        /// 选择要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_SelectElementTool_Click(object sender, EventArgs e)
        {
            ITool tool = new ElementSelectTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 画点要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_DrawPointElementTool_Click(object sender, EventArgs e)
        {
            ITool tool = new DrawPointElementTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 绘制折线要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_DrawPolylineElementTool_Click(object sender, EventArgs e)
        {
            ITool tool = new DrawPolylineElementTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 绘制曲线要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_DrawCurveElementTool_Click(object sender, EventArgs e)
        {
            ITool tool = new DrawCurveElementTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 绘制自由线要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_DrawFreehandElementTool_Click(object sender, EventArgs e)
        {
            ITool tool = new DrawFreehandElementTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 绘制多边形要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_DrawPolygonElementTool_Click(object sender, EventArgs e)
        {
            ITool tool = new DrawPolygonElementTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 绘制矩形要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件发参数</param>
        private void toolStripMenuItem_DrawRectElementTool_Click(object sender, EventArgs e)
        {
            ITool tool = new DrawRectElementTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 绘制椭圆要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_DrawEllipseElementTool_Click(object sender, EventArgs e)
        {
            ITool tool = new DrawEllipseElementTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 绘制圆要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_DrawCircleElementTool_Click(object sender, EventArgs e)
        {
            ITool tool = new DrawCircleElementTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 箭头要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_DrawArrowElementTool_Click(object sender, EventArgs e)
        {
            ITool tool = new DrawArrowElementTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 绘制文本要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件数</param>
        private void toolStripButton_DrawTextElementTool_Click(object sender, EventArgs e)
        {
            ITool tool = new DrawTextElementTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 添加图片要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_DrawPictureElementCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new DrawPictureElementCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
            }
            cmd.OnClick();
        }

        /// <summary>
        /// 指北针
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_AddNorthArrowCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new AddNorthArrowCommand();
            cmd.OnCreate(pageLayoutControl1);
            cmd.OnClick();
        }

        /// <summary>
        /// 比例尺
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_AddPageScaleBarCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new AddPageScaleBarCommand();
            cmd.OnCreate(pageLayoutControl1);
            cmd.OnClick();
        }

        /// <summary>
        /// 图例
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_AddPageLegendCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new AddPageLegendCommand();
            cmd.OnCreate(pageLayoutControl1);
            cmd.OnClick();
        }

        /// <summary>
        /// 编辑节点工具
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_EditElementNodeTool_Click(object sender, EventArgs e)
        {
            ITool tool = new EditElementNodeTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                cmd.OnClick();
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 旋转要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件发参数</param>
        private void toolStripButton_RotateElementTool_Click(object sender, EventArgs e)
        {
            ITool tool = new RotateElementTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
                mapControl1.CurrentTool = tool;
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
                cmd.OnClick();
                pageLayoutControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 导入标绘
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_ImportElementsCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ImportElementsCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
            }
            cmd.OnClick();
        }

        /// <summary>
        /// 导出标绘
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_ExportElementsCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ExportElementsCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
            }
            cmd.OnClick();
        }

        /// <summary>
        /// 删除标绘
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_MarkDeleteCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new MarkDeleteCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
            }
            cmd.OnClick();
        }

        /// <summary>
        /// 清空标绘
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_MarkClearCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new MarkClearCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                cmd.OnCreate(pageLayoutControl1);
            }
            cmd.OnClick();
        }

        #endregion

        #region 编辑（事件）

        /// <summary>
        /// 开始编辑
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_StartEditCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new StartEditCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 保存编辑
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_SaveEditCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new SaveEditCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 结束编辑
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_StopEditCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new StopEditCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 移动要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_MoveFeatureTool_Click(object sender, EventArgs e)
        {
            ITool tool = new MoveFeatureTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 添加要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_AddFeatureCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new AddFeatureCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 删除要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_DeleteFeatureCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new DeleteFeatureCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 编辑要素节点
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_EditFeatureNodeTool_Click(object sender, EventArgs e)
        {
            ITool tool = new EditFeatureNodeTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
                mapControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 旋转要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_RotateFeatureTool_Click(object sender, EventArgs e)
        {
            ITool tool = new PIE.Controls.RotateFeatureTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
                mapControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 属性编辑
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_AttributeEditCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new AttributeEditCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 撤销
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_UndoCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new UndoCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_RedoCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new RedoCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 选择要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件触发参数</param>
        private void toolStripButton_SelectFeatureTool_Click(object sender, EventArgs e)
        {
            ITool tool = new SelectFeatureTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                mapControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 清除要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_ClearSelectionFeaturesCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ClearSelectionFeaturesCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 裁切要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_ClipFeatureTool_Click(object sender, EventArgs e)
        {
            ITool tool = new ClipFeatureTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
                mapControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 合并要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_UnionFeatureCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new UnionFeatureCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 拆分要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_SplitFeatureCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new SplitFeatureCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 整形要素
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_ReshapeFeatureTool_Click(object sender, EventArgs e)
        {
            ITool tool = new ReshapeFeatureTool();
            ICommand cmd = tool as ICommand;
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
                mapControl1.CurrentTool = tool;
            }
        }

        /// <summary>
        /// 点
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_SnappingPointCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new SnappingPointCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 端点
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_SnappingEndCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new SnappingEndCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 折点
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_SnappingVertexCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new SnappingVertexCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 中点
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_SnappingMidPointCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new SnappingMidPointCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 线
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_SnappingEdgeCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new SnappingEdgeCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 追踪
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_TraceCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new TraceCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 创建图层
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_CreateLayerCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new CreateLayerCommand();
            if (tabControlMain.SelectedIndex == 0)
            {
                cmd.OnCreate(mapControl1);
                cmd.OnClick();
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripMenuItem_TocAddVectorData_Click(object sender, EventArgs e)
        {
            ICommand cmd = new AddDataCommand();
            cmd.OnCreate(mapControl1);
            cmd.OnClick();
        }

        #endregion

        #region 输出（事件）

        /// <summary>
        /// 更改布局
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_ChangePageTemplateCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new ChangePageTemplateCommand();
            cmd.OnCreate(pageLayoutControl1);
            cmd.OnClick();
        }

        /// <summary>
        /// 页面设置
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_PageSettingCommand_Click_1(object sender, EventArgs e)
        {
            ICommand cmd = new PageSettingCommand();
            cmd.OnCreate(pageLayoutControl1);
            cmd.OnClick();
        }

        /// <summary>
        /// 导出地图
        /// </summary>
        /// <param name="sender">事件触发器</param>
        /// <param name="e">事件参数</param>
        private void toolStripButton_CartoGraphy_ExportCommand_Click(object sender, EventArgs e)
        {
            ICommand cmd = new CartoGraphy_ExportCommand();
            cmd.OnCreate(pageLayoutControl1);
            cmd.OnClick();
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 初始化函数
        /// </summary>
        private void InitFrm()
        {
            // 汉化
            PIE.Controls.LanguageManager.GetInstance().InstallTranslator();

            //绑定
            mapControl1.FocusMap = pageLayoutControl1.FocusMap;
            this.tocControlMain.SetBuddyControl(pageLayoutControl1);
            pageLayoutControl1.DeActivate();
            mapControl1.Activate();

            ///比例尺控件
            ICommandControl mapScaleCmdControl = new MapScaleCommandControl();
            mapScaleCmdControl.Control = toolStripComboBox_MapScale;
            (mapScaleCmdControl as ICommand).OnCreate(mapControl1);

            //设置Toc右键菜单
            toolStripMenuItem_DeleteLayer.Tag = new DeleteLayerCommand();
            toolStripMenuItem_ZoomToLayer.Tag = new ZoomToLayerCommand();

            //绑定MapControl右键菜单Command
            tullExtent_MenuItem.Tag = new FullExtentCommand();
            rasterIdentify_MenuItem.Tag = new RasterIdentifyTool();
        }

        /// <summary>
        /// 激活地图模式
        /// </summary>
        private void ActivateMapControl()
        {
            pageLayoutControl1.DeActivate();
            mapControl1.Activate();
            //刷新地图
            mapControl1.PartialRefresh(ViewDrawPhaseType.ViewAll);
        }

        /// <summary>
        /// 激活制图模式
        /// </summary>
        private void ActivatePageLayoutControl()
        {
            mapControl1.DeActivate();
            pageLayoutControl1.Activate();
            //刷新地图
            pageLayoutControl1.PartialRefresh(ViewDrawPhaseType.ViewAll);
        }

        /// <summary>
        /// 新建地图工程
        /// </summary>
        private void NewPmd()
        {
            IMapDocument mapDocument = new MapDocument();
            DialogResult resultType = MessageBox.Show("是否保存当前地图工程", "新建地图工程", MessageBoxButtons.YesNoCancel);
            if (resultType == DialogResult.Cancel)
            {
                return;
            }
            else if (resultType == DialogResult.Yes)
            {
                // 获得保存路径信息
                string pmdFilePath = mapDocument.GetDocumentFilename();
                if (string.IsNullOrEmpty(pmdFilePath))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "地图文档另存为：";
                    saveFileDialog.Filter = "PMD|*.pmd";
                    if (saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                    pmdFilePath = saveFileDialog.FileName;
                    if (string.IsNullOrEmpty(pmdFilePath)) return;
                }
                if (!pmdFilePath.EndsWith(".pmd"))
                {
                    pmdFilePath = pmdFilePath + ".pmd";
                }
                mapDocument.SaveAs(pmdFilePath, true, true);
            }

            IMapDocument newMapDocument = new MapDocument();
            newMapDocument.New("");  //新建地图工程文档

            // 为PageLayoutControl设置PageLayout
            IPageLayout newPageLayout = newMapDocument.GetPageLayout();
            pageLayoutControl1.PageLayout = newPageLayout;

            // 为MapControl设置Map
            IMap newMap = (newPageLayout as IActiveView).FocusMap;
            mapControl1.FocusMap = newMap;

            if (tabControlMain.SelectedIndex == 0)
            {
                // 刷新
                ActivateMapControl();
            }
            else if (tabControlMain.SelectedIndex == 1)
            {
                // 刷新
                ActivatePageLayoutControl();
            }
        }

        /// <summary>
        /// 打开地图工程
        /// </summary>
        private void OpenPmd()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "请选择要打开的地图文档：";
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "PMD|*.pmd";
            if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            string pmdNewFilePath = openFileDialog.FileName;
            if (string.IsNullOrEmpty(pmdNewFilePath)) return;

            IMapDocument newMapDocument = new MapDocument();
            newMapDocument.Open(pmdNewFilePath);

            // 为PageLayoutControl设置PageLayout
            IPageLayout newPageLayout = newMapDocument.GetPageLayout();
            pageLayoutControl1.PageLayout = newPageLayout;

            // 为MapControl设置Map
            IMap newMap = (newPageLayout as IActiveView).FocusMap;
            mapControl1.FocusMap = newMap;

            if (tabControlMain.SelectedIndex == 0)
            {
                // 刷新
                pageLayoutControl1.DeActivate();
                mapControl1.Activate();
                mapControl1.PartialRefresh(ViewDrawPhaseType.ViewAll);
            }
            else
            {
                // 刷新
                mapControl1.DeActivate();
                pageLayoutControl1.Activate();
                pageLayoutControl1.PartialRefresh(ViewDrawPhaseType.ViewAll);
            }
        }

        /// <summary>
        /// 保存地图工程
        /// </summary>
        private void SavePmd()
        {
            IMapDocument newMapDocument = new MapDocument();
            string pmdFilePath = newMapDocument.GetDocumentFilename();
            if (string.IsNullOrEmpty(pmdFilePath))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "地图文档保存为：";
                saveFileDialog.Filter = "PMD|*.pmd";
                if (saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                pmdFilePath = saveFileDialog.FileName;
                if (string.IsNullOrEmpty(pmdFilePath)) return;

                if (!pmdFilePath.EndsWith(".pmd"))
                {
                    pmdFilePath = pmdFilePath + ".pmd";
                }
            }
            newMapDocument.ReplaceContents(pageLayoutControl1);
            newMapDocument.SaveAs(pmdFilePath, false, false);
        }

        /// <summary>
        /// 另存为地图工程
        /// </summary>
        private void SaveAsPmd()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "地图文档另存为：";
            saveFileDialog.Filter = "PMD|*.pmd";
            if (saveFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            string pmdFilePath = saveFileDialog.FileName;
            if (string.IsNullOrEmpty(pmdFilePath)) return;

            if (!pmdFilePath.EndsWith(".pmd"))
            {
                pmdFilePath = pmdFilePath + ".pmd";
            }
            IMapDocument newMapDocument = new MapDocument();
            newMapDocument.ReplaceContents(pageLayoutControl1);
            newMapDocument.SaveAs(pmdFilePath, false, false);
        }

        #endregion

        private void 波段合成ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region 1、参数设置
            PIE.CommonAlgo.BandCombination_Exchange_Info info = new PIE.CommonAlgo.BandCombination_Exchange_Info();
            string path = @"D:\PIE\Data\1.tiff";
            IRasterDataset rDataset = DatasetFactory.OpenDataset(path, OpenMode.ReadOnly) as IRasterDataset;

            info.m_vecFileptr = new List<IRasterDataset> { rDataset, rDataset };
            List<int> list1 = new List<int> { 3, 2, 1 };
            info.bands = new List<List<int>> { list1, list1 };
            info.tstrfile = @"D:\PIE\Data\波段合成.tiff";
            info.m_strFileTypeCode = "GTiff";
            PIE.CommonAlgo.Interestregion interestregion = new PIE.CommonAlgo.Interestregion();
            interestregion.SetRegion(0, 0, rDataset.GetRasterYSize(), rDataset.GetRasterXSize());
            info.regioninfo = new List<PIE.CommonAlgo.Interestregion> { interestregion, interestregion };
            info.m_iOutRangeCrossType = 0;

            PIE.SystemAlgo.ISystemAlgo algo = PIE.SystemAlgo.AlgoFactory.Instance().CreateAlgo("PIE.CommonAlgo.dll", "PIE.CommonAlgo.BandCombinationAlgo");
            if (algo == null) return;
            #endregion

            //2、算法执行
            PIE.SystemAlgo.ISystemAlgoEvents algoEvents = algo as PIE.SystemAlgo.ISystemAlgoEvents;
            algo.Name = "波段合成";
            algo.Params = info;
            bool result = PIE.SystemAlgo.AlgoFactory.Instance().ExecuteAlgo(algo);
            //3、结果显示
            ILayer layer = PIE.Carto.LayerFactory.CreateDefaultLayer(@"D:\PIE\Data\波段合成.tiff");
            mapControl1.ActiveView.FocusMap.AddLayer(layer); mapControl1.ActiveView.PartialRefresh(ViewDrawPhaseType.ViewAll);

        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ILayer layer0 = PIE.Carto.LayerFactory.CreateDefaultLayer(@"D:\PIE\Data\1.tiff");
            mapControl1.ActiveView.FocusMap.AddLayer(layer0); mapControl1.ActiveView.PartialRefresh(ViewDrawPhaseType.ViewAll);
        }

        private void 图像重采样ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IHookHelper pHook = new HookHelper();
            pHook.Hook = mapControl1;
            FrmImgClassReSample frmClassPostSieve = new FrmImgClassReSample(pHook);
            if (frmClassPostSieve.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            // 重采样
            PIE.CommonAlgo.ImageResample_Exchange_Info info = frmClassPostSieve.ExChangeData;
            PIE.SystemAlgo.ISystemAlgo algo = PIE.SystemAlgo.AlgoFactory.Instance().CreateAlgo("PIE.CommonAlgo.dll", "PIE.CommonAlgo.ImageResampleAlgo");
            if (algo == null) return;
            algo.Name = "重采样";
            algo.Params = info;
            bool result = PIE.SystemAlgo.AlgoFactory.Instance().ExecuteAlgo(algo);
            if (result)
            {
                MessageBox.Show("执行成功");
                ILayer layer = LayerFactory.CreateDefaultLayer(info.OutputFilePath);
                if (layer == null) return;
                mapControl1.ActiveView.FocusMap.AddLayer(layer);
                mapControl1.ActiveView.PartialRefresh(ViewDrawPhaseType.ViewAll);
            }
        }

        private void 自定义滤波ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 1、参数设置
            PIE.CommonAlgo.StImageFittleCustom info = new PIE.CommonAlgo.StImageFittleCustom();

            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "所有文件|*.*";
            oFD.Multiselect = false;
            oFD.Title = "输入影像";
            if (oFD.ShowDialog() != DialogResult.OK)
                return;

            OpenFileDialog sFD = new OpenFileDialog();
            oFD.Filter = "所有文件|*.*";
            oFD.Multiselect = false;
            oFD.Title = "输出影像";
            if (oFD.ShowDialog() != DialogResult.OK)
                return;

            info.InputFilePath = oFD.FileName;
            info.OutputFilePath = sFD.FileName;

            //info.InputFilePath = @"D:\PIE\Data\1.tiff";
            //info.OutputFilePath = @"D:\PIE\Data\ip_result18.tiff";


            info.LM = 3;
            info.LN = 3;
            info.FilterType = 0;
            info.Kernel = new float[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            info.FileTypeCode = "GTiff";
            info.LowBands = new List<int> { 0, 1, 2 };

            PIE.SystemAlgo.ISystemAlgo algo = PIE.SystemAlgo.AlgoFactory.Instance().CreateAlgo("PIE.CommonAlgo.dll", "PIE.CommonAlgo.ImgProFiltCustomAlgo");
            if (algo == null) return;
            #endregion

            //2、算法执行
            PIE.SystemAlgo.ISystemAlgoEvents algoEvents = algo as PIE.SystemAlgo.ISystemAlgoEvents;
            algo.Name = " 自定义滤波";
            algo.Params = info;
            bool result = PIE.SystemAlgo.AlgoFactory.Instance().ExecuteAlgo(algo);

            //3、结果显示
            ILayer layer = PIE.Carto.LayerFactory.CreateDefaultLayer(@"D:\PIE\Data\ip_result18.tiff");
            mapControl1.ActiveView.FocusMap.AddLayer(layer); mapControl1.ActiveView.PartialRefresh(ViewDrawPhaseType.ViewAll);

        }

        private void 组合运算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sCombOutPath = "D:\\PIE\\DATA\\输出.tiff";

            #region 1、参数设置
            PIE.CommonAlgo.BandOper_Exchange_Info info = new PIE.CommonAlgo.BandOper_Exchange_Info();
            info.StrExp = "b2-b1";
            info.SelectFileBands = new List<int> { 3, 2 };//band3和band2 根据运算公式的波段大小先后顺序确定 b1的选择波段就是3；
            info.SelectFileNames = new List<string> { @"D:\PIE\DATA\1.tiff", @"D:\PIE\DATA\1.tiff" };//分别为band3和band2数据路径
            info.OutputFilePath = @"D:\PIE\DATA\输出.tiff";

            info.FileTypeCode = "GTiff";

            PIE.SystemAlgo.ISystemAlgo algo = PIE.SystemAlgo.AlgoFactory.Instance().CreateAlgo("PIE.CommonAlgo.dll", "PIE.CommonAlgo.BandOperAlgo");
            if (algo == null) return;
            #endregion

            //2、算法执行
            PIE.SystemAlgo.ISystemAlgoEvents algoEvents = algo as PIE.SystemAlgo.ISystemAlgoEvents;
            algo.Name = "波段运算";
            algo.Params = info;

            //3、结果显示
            bool result = PIE.SystemAlgo.AlgoFactory.Instance().ExecuteAlgo(algo);
            if (result)
            {
                MessageBox.Show("波段算法执行成功");
                ILayer layer = LayerFactory.CreateDefaultLayer(info.OutputFilePath);
            }


            // 重采样

            IHookHelper pHook = new HookHelper();
            pHook.Hook = mapControl1;
            FrmImgClassReSample frmClassPostSieve = new FrmImgClassReSample(pHook);
            if (frmClassPostSieve.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;


            PIE.CommonAlgo.ImageResample_Exchange_Info info1 = frmClassPostSieve.ExChangeData;
            PIE.SystemAlgo.ISystemAlgo algo1 = PIE.SystemAlgo.AlgoFactory.Instance().CreateAlgo("PIE.CommonAlgo.dll", "PIE.CommonAlgo.ImageResampleAlgo");
            if (algo1 == null) return;
            algo1.Name = "重采样";
            algo1.Params = info1;
            bool result2 = PIE.SystemAlgo.AlgoFactory.Instance().ExecuteAlgo(algo1);
            if (result2)
            {
                MessageBox.Show("执行成功");
                ILayer layer = LayerFactory.CreateDefaultLayer(info1.OutputFilePath);
                if (layer == null) return;
                mapControl1.ActiveView.FocusMap.AddLayer(layer);
                mapControl1.ActiveView.PartialRefresh(ViewDrawPhaseType.ViewAll);
            }

            BandUnion(info.OutputFilePath, frmClassPostSieve.ExChangeData.OutputFilePath);

        }


        //波段组合
        public void BandUnion(string sOut1, string sOut2)
        {
            #region 1、参数设置
            PIE.CommonAlgo.BandCombination_Exchange_Info info = new PIE.CommonAlgo.BandCombination_Exchange_Info();

            IRasterDataset rDataset_1 = DatasetFactory.OpenDataset(sOut1, OpenMode.ReadOnly) as IRasterDataset;
            IRasterDataset rDataset_2 = DatasetFactory.OpenDataset(sOut2, OpenMode.ReadOnly) as IRasterDataset;
            info.m_vecFileptr = new List<IRasterDataset> { rDataset_1, rDataset_2 };
            List<int> list1 = new List<int> { 0 };
            List<int> list2 = new List<int> { 1 , 2 };
            info.bands = new List<List<int>> { list1, list2 };
            info.tstrfile = @"D:\PIE\Data\组合输出.tiff";
            info.m_strFileTypeCode = "GTiff";
            PIE.CommonAlgo.Interestregion interestregion = new PIE.CommonAlgo.Interestregion();
            interestregion.SetRegion(0, 0, rDataset_1.GetRasterYSize(), rDataset_2.GetRasterXSize());
            info.regioninfo = new List<PIE.CommonAlgo.Interestregion> { interestregion, interestregion };
            info.m_iOutRangeCrossType = 0;

            PIE.SystemAlgo.ISystemAlgo algo = PIE.SystemAlgo.AlgoFactory.Instance().CreateAlgo("PIE.CommonAlgo.dll", "PIE.CommonAlgo.BandCombinationAlgo");
            if (algo == null) return;
            #endregion

            //2、算法执行
            PIE.SystemAlgo.ISystemAlgoEvents algoEvents = algo as PIE.SystemAlgo.ISystemAlgoEvents;
            algo.Name = "波段合成";
            algo.Params = info;
            bool result = PIE.SystemAlgo.AlgoFactory.Instance().ExecuteAlgo(algo);
            //3、结果显示
            ILayer layer = PIE.Carto.LayerFactory.CreateDefaultLayer(@"D:\PIE\Data\组合输出.tiff");
            mapControl1.ActiveView.FocusMap.AddLayer(layer); 
            mapControl1.ActiveView.PartialRefresh(ViewDrawPhaseType.ViewAll);
        }



    }
}
