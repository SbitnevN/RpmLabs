using MedRepairTrack.RequestsForm.Request.Model;
using System;
using System.Windows;

namespace MedRepairTrack.Request
{
    public partial class RequestEditor : Window
    {
        public RequestModel Request {  get; private set; }

        public RequestEditor(RequestModel request)
        {
            InitializeComponent();
            Request = request;
            DataContext = Request;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
