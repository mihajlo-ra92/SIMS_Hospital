﻿#pragma checksum "..\..\..\..\View\AppointmentEditPatient.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1C72D9316062142109BD1BDD7AAEAC78D4B9269C"
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
    /// AppointmentEditPatient
    /// </summary>
    public partial class AppointmentEditPatient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\View\AppointmentEditPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logoutUser;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\View\AppointmentEditPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePicker;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\View\AppointmentEditPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox timeTextHour;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\View\AppointmentEditPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox timeTextMinutes;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\View\AppointmentEditPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox doctorComboBox;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\View\AppointmentEditPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveAppointmentEditButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Sims-Hospital;component/view/appointmenteditpatient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\AppointmentEditPatient.xaml"
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
            
            #line 39 "..\..\..\..\View\AppointmentEditPatient.xaml"
            this.logoutUser.Click += new System.Windows.RoutedEventHandler(this.LogoutUser_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.datePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.timeTextHour = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.timeTextMinutes = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.doctorComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.saveAppointmentEditButton = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\..\View\AppointmentEditPatient.xaml"
            this.saveAppointmentEditButton.Click += new System.Windows.RoutedEventHandler(this.SaveAppointmentEditButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

