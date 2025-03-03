using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using MedRepairTrack.Application.RequestList.Request.Model;
using MedRepairTrack.Application.RequestList.Request;
using MedRepairTrack.Core.Extensions;
using MedRepairTrack.Core.Abstractions;
using MedRepairTrack.Application.RequestList.Request.Queries;

namespace MedRepairTrack.Application.RequestList
{
    /// <summary>
    /// Interaction logic for RequestListEditor.xaml
    /// </summary>
    public partial class RequestListEditor : UserControl
    {
        private RequestQueries _requestQueries => RequestQueries.Instance;
        public ObservableCollection<RequestModel> Request { get; } = new ObservableCollection<RequestModel>();

        public RequestListEditor()
        {
            InitializeComponent();
            DataContext = this;
            foreach (RequestModel request in _requestQueries.GetAll())
            {
                Request.Add(request);
            }
        }

        private void AddNewRequest(object sender, RoutedEventArgs e)
        {
            RequestModel request = new RequestModel();
            RequestEditor requestEditor = new RequestEditor(request);
            bool result = requestEditor.ShowDialog() ?? false;
            if (result)
            {
                _requestQueries.Add(request);
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
                _requestQueries.Edit(requestEditor.RequestModel);
                Request[Request.IndexOf(requestModel)] = requestEditor.RequestModel;
                Request.Refresh();
            }
        }
    }
}
