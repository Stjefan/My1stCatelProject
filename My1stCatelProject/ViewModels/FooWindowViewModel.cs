using Catel.MVVM;
using My1stCatelProject.Models;
using Catel.Data;
using Catel;

namespace My1stCatelProject.ViewModels
{
    public class FooWindowViewModel : ViewModelBase
    {
        public FooWindowViewModel(Foo model)
        {
            Model = model;
        }

        public override string Title { get => "FooWindow"; protected set => base.Title = value; }

        [Model]
        public Foo Model { get; set; }

        [ViewModelToModel(nameof(Model))]
        public string TextProp { get; set; }

    }

    }
