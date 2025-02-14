using MedRepairTrack.RequestsForm.Request.Model;
using System.Collections.ObjectModel;
using System.Windows;
using MedRepairTrack.Core.Extensions;
using MedRepairTrack.Request;

namespace MedRepairTrack.RequestList
{
    public partial class RequestListForm : Window
    {
        public ObservableCollection<RequestModel> Requests { get; } = new ObservableCollection<RequestModel>();  

        public RequestListForm()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void AddNewRequest(object sender, RoutedEventArgs e)
        {

            RequestModel requestModel = new RequestModel();
            RequestEditor messageBox = new RequestEditor(requestModel);
            if (messageBox.ShowDialog() ?? false)
            {
                Requests.Add(requestModel);
                Requests.Refresh();
            }
        }

        public void EditNewRequest(object sender, RoutedEventArgs e)
        {
            RequestModel? requestModel = RequestsListView.SelectedItem as RequestModel;

            if (requestModel == null)
            {
                return;
            }

            RequestEditor messageBox = new RequestEditor(requestModel);
            if (messageBox.ShowDialog() ?? false)
            {
                Requests.Refresh();
            }
        }

    }
}
