﻿#pragma checksum "..\..\AdminTechnique.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8F8E0992C512BAB4351FAFD4459B981878A75FE9601B5BCEE307AA9D64614C51"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Fitnes {
    
    
    /// <summary>
    /// AdminTechnique
    /// </summary>
    public partial class AdminTechnique : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 70 "..\..\AdminTechnique.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxTechnicianNumber;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\AdminTechnique.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxTechniqueName;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\AdminTechnique.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxTechniqueModel;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\AdminTechnique.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxYearOfManufacture;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\AdminTechnique.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxRentalCost;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\AdminTechnique.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxState;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Fitnes;component/admintechnique.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminTechnique.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 23 "..\..\AdminTechnique.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 38 "..\..\AdminTechnique.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TextBoxTechnicianNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBoxTechniqueName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TextBoxTechniqueModel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TextBoxYearOfManufacture = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TextBoxRentalCost = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ComboBoxState = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            
            #line 86 "..\..\AdminTechnique.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAdd_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 87 "..\..\AdminTechnique.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonEdit_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 88 "..\..\AdminTechnique.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

