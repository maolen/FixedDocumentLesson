﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;

namespace FixedDocumentLesson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UploadXpsFile(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            var isProcessed = openFileDialog.ShowDialog();

            if(isProcessed.Value)
            {
                var xpsFilePath = openFileDialog.FileName;
                using (var xpsDocument = new XpsDocument(xpsFilePath, FileAccess.ReadWrite))
                {
                    documentViewer.Document = xpsDocument.GetFixedDocumentSequence();
                }
            }
        }

        private void SaveXpsAs(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            var hasResult = saveFileDialog.ShowDialog();

            if(hasResult.Value)
            {
                var xpsFilePath = saveFileDialog.FileName;
                using (var xpsDocument = new XpsDocument(xpsFilePath, FileAccess.ReadWrite))
                {
                    XpsDocumentWriter writer = new XpsDocumentWriter.CreateXpsDocumentWriter(xpsDocument);
                    writer.Write(fixedDocument);
                }
            }
        }
    }
}
