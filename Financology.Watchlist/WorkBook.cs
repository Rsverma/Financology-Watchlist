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
using System.Windows.Forms;

using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.DataGrid;

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
        private DataManager _dm = null;
        #endregion

        #region Constructor
        public WorkBook(Watchlist frm)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            _dm = new DataManager();
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
            _grid.DataSource = _dm.liveFeeds;
            _grid.VisibleChanged += new EventHandler(_grid_VisibleChanged);
            i++;
            this.ResumeLayout(true);
            #endregion
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
        internal void Paste()
        {
            this._grid.Focus();
            //this._grid.Model.CutPaste.Paste();
        }

        internal void Cut()
        {
            this._grid.Focus();
            //this._grid.Model.CutPaste.Cut();
        }

        internal void Copy()
        {
            this._grid.Focus();
            //this._grid.Model.CutPaste.Copy();
        }
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