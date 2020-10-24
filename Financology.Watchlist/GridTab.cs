#region Copyright Syncfusion Inc. 2001 - 2020
//
//  Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Events;

namespace Financology.Watchlist
{
    /// <summary>
    /// Summary description for Watchlist.
    /// </summary>
    public class GridTab : IDisposable
    {
        #region Private Variables
        internal SfDataGrid _grid = null;
        #endregion

        #region Constructor
        public GridTab()
        {
            this.MyInit();
        }
        #endregion

        private void MyInit()
        {
            # region Initial Settings
            _grid = new SfDataGrid();
            _grid.Dock = System.Windows.Forms.DockStyle.Fill;
            _grid.Location = new System.Drawing.Point(0, 0);
            _grid.Name = "dataGrid";
            _grid.Size = new System.Drawing.Size(791, 345);
            _grid.TabIndex = 1;
            _grid.Text = "dataGrid";
            _grid.AllowEditing = false;
            _grid.BackColor = Color.Gray;
            DataManager.instance._currentUI = this;
            _grid.DataSource = DataManager.instance.liveFeeds;
            _grid.QueryCellStyle += _grid_QueryCellStyle;
            _grid.AllowResizingColumns = true;
            _grid.AllowDraggingColumns = true;
            _grid.AllowFiltering = true;
            _grid.AllowSorting = true;
            _grid.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Single;
            _grid.Style.HeaderStyle.BackColor = Color.FromArgb(100, 62, 86, 125);
            _grid.Style.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            _grid.Style.HeaderStyle.Font = new Syncfusion.WinForms.DataGrid.Styles.GridFontInfo(new Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            _grid.RecordContextMenu = new ContextMenuStrip();
            _grid.RecordContextMenu.Items.Add("Delete", null, OnDeleteClicked);

            #endregion
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_grid.SelectedIndex >= 0)
            {
                DataManager.instance.DeleteRow(_grid.SelectedIndex);
            }
        }

        private void _grid_QueryCellStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryCellStyleEventArgs e)
        {
            switch (e.Column.MappingName)
            {

                case "Symbol":
                    e.Style.Font.Bold = true;
                    break;
                case "Ask":
                    if (DataManager.instance.colors.ContainsKey(e.RowIndex) && DataManager.instance.colors[e.RowIndex].isAskGreater.HasValue)
                        e.Style.TextColor = DataManager.instance.colors[e.RowIndex].isAskGreater.Value ? Color.Green : Color.Red;
                    break;
                case "Last":
                    if (DataManager.instance.colors.ContainsKey(e.RowIndex) && DataManager.instance.colors[e.RowIndex].isLastGreater.HasValue)
                        e.Style.TextColor = DataManager.instance.colors[e.RowIndex].isLastGreater.Value ? Color.Green : Color.Red;
                    break;
                case "Bid":
                    if (DataManager.instance.colors.ContainsKey(e.RowIndex) && DataManager.instance.colors[e.RowIndex].isBidGreater.HasValue)
                        e.Style.TextColor = DataManager.instance.colors[e.RowIndex].isBidGreater.Value ? Color.Green : Color.Red;
                    break;
                case "Change":
                case "ChangePercent":
                    if (DataManager.instance.colors.ContainsKey(e.RowIndex) && DataManager.instance.colors[e.RowIndex].isChangePositive.HasValue)
                        e.Style.TextColor = DataManager.instance.colors[e.RowIndex].isChangePositive.Value ? Color.Green : Color.Red;
                    break;
            }
        }


        #region Dispose Methods
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_grid != null)
                {
                    _grid.QueryCellStyle -= _grid_QueryCellStyle;
                    _grid.Dispose();
                    _grid = null;
                }
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}