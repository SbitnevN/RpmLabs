using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using MedRepairTrack.Application.RequestList.Request.Model;
using MedRepairTrack.Application.RequestList.Request;
using MedRepairTrack.Core.Extensions;
using MedRepairTrack.Application.UserList.User.Model;
using MedRepairTrack.Application.UserList.User;
using MedRepairTrack.Core.Abstractions;

namespace MedRepairTrack.Application.RequestList
{
    /// <summary>
    /// Interaction logic for RequestListEditor.xaml
    /// </summary>
    public partial class RequestListEditor : UserControl
    {
        public ObservableCollection<RequestModel> Request { get; } = new ObservableCollection<RequestModel>();

        public RequestListEditor()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void AddNewRequest(object sender, RoutedEventArgs e)
        {
            RequestModel request = new RequestModel();
            RequestEditor requestEditor = new RequestEditor(request);
            bool result = requestEditor.ShowDialog() ?? false;
            if (result)
            {
                Request.Add(request);
                Request.Refresh();
            }
        }

        private void EditRequest(object sender, RoutedEventArgs e)
        {
            if (RequestListView.SelectedItem == null)
            {
                return;
            }

            RequestModel requestModel = (RequestModel)RequestListView.SelectedItem;
            RequestEditor requestEditor = new RequestEditor((RequestModel)requestModel.Clone(), FormState.Update);

            bool result = requestEditor.ShowDialog() ?? false;
            if (result)
            {
                Request[Request.IndexOf(requestModel)] = requestEditor.RequestModel;
                Request.Refresh();
            }
        }
    }
}
