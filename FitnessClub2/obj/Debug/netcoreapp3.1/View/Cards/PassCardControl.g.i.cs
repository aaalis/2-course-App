﻿#pragma checksum "..\..\..\..\..\View\Cards\PassCardControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3A610E2EE35DF1F4158C229DF989D4A864FF4931"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FitnessClub2.View.Cards;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace FitnessClub2.View.Cards {
    
    
    /// <summary>
    /// PassCardControl
    /// </summary>
    public partial class PassCardControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 114 "..\..\..\..\..\View\Cards\PassCardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PassService;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\..\..\View\Cards\PassCardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn ServiceName;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\..\View\Cards\PassCardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn ServiceAvTime;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\..\..\View\Cards\PassCardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PassContract;
        
        #line default
        #line hidden
        
        
        #line 193 "..\..\..\..\..\View\Cards\PassCardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn ContractNumber;
        
        #line default
        #line hidden
        
        
        #line 197 "..\..\..\..\..\View\Cards\PassCardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn ContractBegin;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\..\..\View\Cards\PassCardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn ContractEnd;
        
        #line default
        #line hidden
        
        
        #line 205 "..\..\..\..\..\View\Cards\PassCardControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn ContractClient_Name;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FitnessClub2;component/view/cards/passcardcontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Cards\PassCardControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PassService = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.ServiceName = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 3:
            this.ServiceAvTime = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.PassContract = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.ContractNumber = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.ContractBegin = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.ContractEnd = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 8:
            this.ContractClient_Name = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

