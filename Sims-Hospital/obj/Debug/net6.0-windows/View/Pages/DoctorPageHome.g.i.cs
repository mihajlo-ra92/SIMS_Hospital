﻿#pragma checksum "..\..\..\..\..\View\Pages\DoctorPageHome.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "486C05125710007DC496D33E9D94E810FFAF941E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Sims_Hospital.View;
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


namespace Sims_Hospital.View {
    
    
    /// <summary>
    /// DoctorPageHome
    /// </summary>
    public partial class DoctorPageHome : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 70 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logoutUser;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editAppointment;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteAppointment;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button showReport;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button sendReport;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CustomerGrid;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Calendar cldSample;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Sims-Hospital;component/view/pages/doctorpagehome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.logoutUser = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
            this.logoutUser.Click += new System.Windows.RoutedEventHandler(this.LogoutUser_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.editAppointment = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
            this.editAppointment.Click += new System.Windows.RoutedEventHandler(this.EditAppointment_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.deleteAppointment = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
            this.deleteAppointment.Click += new System.Windows.RoutedEventHandler(this.DeleteAppointment_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.showReport = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
            this.showReport.Click += new System.Windows.RoutedEventHandler(this.showReport_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.sendReport = ((System.Windows.Controls.Button)(target));
            
            #line 94 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
            this.sendReport.Click += new System.Windows.RoutedEventHandler(this.sendReport_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CustomerGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.cldSample = ((System.Windows.Controls.Calendar)(target));
            
            #line 127 "..\..\..\..\..\View\Pages\DoctorPageHome.xaml"
            this.cldSample.SelectedDatesChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.cldSample_SelectedDatesChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

