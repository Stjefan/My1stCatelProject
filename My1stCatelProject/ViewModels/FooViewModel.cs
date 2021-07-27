using Catel.MVVM;
using My1stCatelProject.Models;
using Catel.Data;
using Catel;

namespace My1stCatelProject.ViewModels
{
    public class FooViewModel : ViewModelBase
    {
        public FooViewModel(Foo model)
        {
            Model = model;
        }

        [Model]
        public Foo Model { get; set; }

        [ViewModelToModel(nameof(Model))]
        public string TextProp { get; set; }

        

    }

    }
