using Catel.Data;
using Catel.IoC;
using Catel.MVVM;
using Catel.Services;
using My1stCatelProject.Models;
using System.ComponentModel;
using System.Threading.Tasks;
using Catel;

namespace My1stCatelProject.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        private readonly IUIVisualizerService _uiVisualizerService;
        public MainWindowViewModel(IUIVisualizerService uiVisualizerService)
        {
            _uiVisualizerService = uiVisualizerService;

            EditCommand = new TaskCommand(OnEdit);
        }

        public override string Title { get { return "Welcome to My1stCatelProject"; } }

        public Foo MyFoo
        {
            get { return GetValue<Foo>(MyFooProperty); }
            set { SetValue(MyFooProperty, value); }
        }

        public static readonly PropertyData MyFooProperty = RegisterProperty(nameof(MyFoo), typeof(Foo), () => new Foo() { TextProp = "XY" });

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }

        public TaskCommand EditCommand { get; set; }

        private async Task OnEdit()
        {
            var typeFactory = this.GetTypeFactory();
            var fooWindowViewModel = typeFactory.CreateInstanceWithParametersAndAutoCompletion<FooWindowViewModel>(MyFoo);
            if (await _uiVisualizerService.ShowDialogAsync(fooWindowViewModel) ?? false)
            {
                // Comment the line below to reproduce unexpected behaviour
                await fooWindowViewModel.SaveAndCloseViewModelAsync(); // This works
            } else
            {
                // Comment the line below to reproduce unexpected behaviour
                await fooWindowViewModel.CancelAndCloseViewModelAsync(); // This works
                ((IEditableObject)fooWindowViewModel).CancelEdit(); // Doesnt work either
            }
        }
    }

    }
