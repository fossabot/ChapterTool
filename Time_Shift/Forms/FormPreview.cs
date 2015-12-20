﻿using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ChapterTool.Forms
{
    public partial class FormPreview : Form
    {
        private Point _mainPos;

        public FormPreview(string text,Point pos)
        {
            InitializeComponent();
            cTextBox1.Text = text;
            _mainPos       = pos;
            ScrollBarSet();
            Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
        }

        private void ScrollBarSet()
        {
            if (cTextBox1.Lines.Select(item => item.Length).Max() > 40 && cTextBox1.Lines.Length > 20)
            {
                cTextBox1.ScrollBars = ScrollBars.Both;
            }
            else if (cTextBox1.Lines.Length > 20)
            {
                cTextBox1.ScrollBars = ScrollBars.Vertical;
            }
        }

        public void UpdateText(string text)
        {
            cTextBox1.Text = text;
            ScrollBarSet();
        }

        private void cTextBox1_DoubleClick(object sender, EventArgs e) => Close();


        private void FormPreview_Load(object sender, EventArgs e)
        {
            _mainPos.X = _mainPos.X - Size.Width;
            Location   = _mainPos;
        }

        private void FormPreview_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
