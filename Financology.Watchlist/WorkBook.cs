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
    public class WorkBook : Office2007Form
    {
        #region Private Variables
        private System.ComponentModel.IContainer components = null;
        internal SfDataGrid _grid = null;
        Watchlist form;
        #endregion

        #region Constructor
        public WorkBook(Watchlist frm)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            
            this.MyInit();
            form = frm;
        }
        #endregion

        #region Override Methods
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            if (this._grid != null)
            {
                this._grid.VisibleChanged -= new EventHandler(_grid_VisibleChanged);
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkBook));
            
            this.SuspendLayout();
            // 
            // WorkBook
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(776, 502);
            //this.Controls.Add(this.tabBarSplitterControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.ControlBox = false;
            this.Name = "WorkBook";
            this.Text = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.WorkBook_Activated);
            this.Deactivate += new System.EventHandler(this.WorkBook_Deactivate);
            this.ResumeLayout(false);
        }

        internal ArrayList HiddenSheets = new ArrayList();

        //Add the sheet 
        int i = 0;
        private void MyInit()
        {
            # region Initial Settings
            this.SuspendLayout();
            _grid = new SfDataGrid();
            _grid.Dock = DockStyle.Fill;
            _grid.Name = string.Format("SfDataGrid{0}", i + 1);
            _grid.Text = string.Format("SfDataGrid{0}", i + 1);
            _grid.AllowEditing = false;
            DataManager.instance._currentUI = this;
            _grid.DataSource = DataManager.instance.liveFeeds;
            _grid.VisibleChanged += new EventHandler(_grid_VisibleChanged);
            _grid.QueryCellStyle += _grid_QueryCellStyle;
            _grid.AllowResizingColumns = true;
            _grid.AllowDraggingColumns = true;
            _grid.AllowFiltering = true;
            _grid.AllowSorting = true;
            _grid.SelectionMode = Syncfusion.WinForms.DataGrid.Enums.GridSelectionMode.Single;
            _grid.Style.HeaderStyle.BackColor = Color.FromArgb(100,62,86,125);
            _grid.Style.CellStyle.HorizontalAlignment = HorizontalAlignment.Center;
            _grid.Style.HeaderStyle.Font = new Syncfusion.WinForms.DataGrid.Styles.GridFontInfo(new Font("Segoe UI", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))));
            _grid.RecordContextMenu = new ContextMenuStrip();
            _grid.RecordContextMenu.Items.Add("Delete", null, OnDeleteClicked);
            i++;
            this.ResumeLayout(true);
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

        #endregion

        #region Create New Sheet

        /// <summary>
        /// Add a new worksheet for the SpreadsheetControl
        /// </summary>
        public void AddNewWorkheet()
        {
            SfDataGrid _grid = new SfDataGrid();

            // 
            // _grid
            // 
            //_grid.ContextMenuStrip = gridCMStrip;
            _grid.Location = new System.Drawing.Point(0, 0);
            _grid.Name = string.Format("SfDataGrid{0}", i + 1);
            _grid.Text = string.Format("SfDataGrid{0}", i + 1);

            i++;
        }
        #endregion

        #region Methods
        #endregion

        #region Events

        private void WorkBook_Activated(object sender, System.EventArgs e)
        {
            (this.MdiParent as Watchlist).workBook = this;
        }

        private void WorkBook_Deactivate(object sender, System.EventArgs e)
        {
            (this.MdiParent as Watchlist).workBook = null;
        }

        private void _grid_VisibleChanged(object sender, EventArgs e)
        {
        }

        #endregion
    }
}