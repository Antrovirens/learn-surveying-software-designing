using PIE.AxControls;
using PIE.Carto;
using PIE.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PIEAppication.Command
{
    /// <summary>
    /// 自定义加载数据类
    /// </summary>
    public class AddDataCommand : BaseCommand
    {
        #region 私有变量

        /// <summary>
        /// 地图实例
        /// </summary>
        private IMapControl m_MapControl;

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public AddDataCommand()
        {
            base.Caption = "加载数据";
            base.ToolTip = "加载数据";
        }

        /// <summary>
        /// 重写单击按钮事件
        /// </summary>
        public override void OnClick()
        {
            try
            {
                // 打开文件对话框
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "请选择要打开的数据：";
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Shape Files|*.shp;*.000|Raster Files|*.tif;*.tiff;*.dat;*.bmp;*.img;*.jpg|HDF Files|*.hdf;*.h5|NC Files|*.nc";
                if (openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                // 打开文件刷新
                string filePath = openFileDialog.FileName;
                m_HookHelper.FocusMap.AddLayer(PIE.Carto.LayerFactory.CreateDefaultLayer(filePath));
                m_HookHelper.ActiveView.PartialRefresh(ViewDrawPhaseType.ViewAll);
            }
            catch (Exception ex)
            {

            }
        }

    }
}
