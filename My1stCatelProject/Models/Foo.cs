using Catel.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace My1stCatelProject.Models
{
    public class Foo : ModelBase
    {
        public string TextProp { get; set; }

        public bool BoolProp { get; set; }

        protected override void OnBeginEdit(BeginEditEventArgs e)
        {
            ;
            base.OnBeginEdit(e);
        }


        protected override void OnCancelEdit(EditEventArgs e)
        {
            ;
            base.OnCancelEdit(e);
        }
    }
}
