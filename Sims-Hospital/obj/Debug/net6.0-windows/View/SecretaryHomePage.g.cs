﻿#pragma checksum "..\..\..\..\View\SecretaryHomePage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03845DBB6EDBC9060623DE71EEC8D6B1579C9C3D"
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
    /// SecretaryHomePage
    /// </summary>
    public partial class SecretaryHomePage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\..\View\SecretaryHomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button logoutUser;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\View\SecretaryHomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addPatient;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\View\SecretaryHomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editPatient;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\View\SecretaryHomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deletePatient;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\View\SecretaryHomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editAllergies;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\View\SecretaryHomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editAppointments;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\View\SecretaryHomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox patientsList;
        
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
            System.Uri resourceLocater = new System.Uri("/Sims-Hospital;component/view/secretaryhomepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\SecretaryHomePage.xaml"
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
            
            #line 31 "..\..\..\..\View\SecretaryHomePage.xaml"
            this.logoutUser.Click += new System.Windows.RoutedEventHandler(this.LogoutUser_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.addPatient = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\View\SecretaryHomePage.xaml"
            this.addPatient.Click += new System.Windows.RoutedEventHandler(this.AddPatient_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.editPatient = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\View\SecretaryHomePage.xaml"
            this.editPatient.Click += new System.Windows.RoutedEventHandler(this.EditPatient_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.deletePatient = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\View\SecretaryHomePage.xaml"
            this.deletePatient.Click += new System.Windows.RoutedEventHandler(this.DeletePatient_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.editAllergies = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\View\SecretaryHomePage.xaml"
            this.editAllergies.Click += new System.Windows.RoutedEventHandler(this.EditAllergies_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.editAppointments = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\View\SecretaryHomePage.xaml"
            this.editAppointments.Click += new System.Windows.RoutedEventHandler(this.EditAppointments_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.patientsList = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

