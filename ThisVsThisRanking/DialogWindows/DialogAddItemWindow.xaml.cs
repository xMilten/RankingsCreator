using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace ThisVsThisRanking.DialogWindows;
/// <summary>
/// Interaktionslogik für DialogAddItemWindow.xaml
/// </summary>
public partial class DialogAddParticipantWindow : Window {
    public List<string> FileNames { get; private set; }

    public DialogAddParticipantWindow() {
        InitializeComponent();
        inputName.Focus();
    }

    private void okButton_Click(object sender, RoutedEventArgs e) {
        DialogResult = true;
    }

    private void browseButton_Click(object sender, RoutedEventArgs e) {
        OpenFileDialog fileDialog = new() {
            Filter = "Bilddateien(*.BMP;*.JPG;*.JPEG;*.PNG|*.BMP;*.JPG;*.JPEG;*.PNG|Alle Dateien (*.*)|*.*)",
            Multiselect = true
        };

        if (fileDialog.ShowDialog() == true) {
            if (fileDialog.FileNames.Length > 1) {
                FileNames = fileDialog.FileNames.ToList();
                DialogResult = true;
                Close();
            }
            inputImage.Text = fileDialog.FileName;
            inputName.Text = Path.GetFileNameWithoutExtension(fileDialog.FileName);
        }
    }
}
