﻿#pragma checksum "..\..\AdminClients.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B6E7F68753779F393696D4F628EC05567F97BAD4BFCA2227CF29BF7080765ECE"
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
    /// AdminClients
    /// </summary>
    public partial class AdminClients : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\AdminClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgrdClients;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\AdminClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxCompanyName;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\AdminClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPhoneNumber;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\AdminClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxAddress;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\AdminClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxEmail;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\AdminClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxContactPersonName;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\AdminClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxContactPersonSurname;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\AdminClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxContactPersonMiddlename;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\AdminClients.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxContractNumber;
        
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
            System.Uri resourceLocater = new System.Uri("/Fitnes;component/adminclients.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminClients.xaml"
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
            
            #line 26 "..\..\AdminClients.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 42 "..\..\AdminClients.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dgrdClients = ((System.Windows.Controls.DataGrid)(target));
            
            #line 58 "..\..\AdminClients.xaml"
            this.dgrdClients.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgrdClients_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TextBoxCompanyName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TextBoxPhoneNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TextBoxAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.TextBoxEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.TextBoxContactPersonName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.TextBoxContactPersonSurname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.TextBoxContactPersonMiddlename = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.TextBoxContractNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            
            #line 92 "..\..\AdminClients.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAdd_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 93 "..\..\AdminClients.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonEdit_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 94 "..\..\AdminClients.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

