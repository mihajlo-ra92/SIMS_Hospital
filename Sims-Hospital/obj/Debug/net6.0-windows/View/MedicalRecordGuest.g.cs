﻿#pragma checksum "..\..\..\..\View\MedicalRecordGuest.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5C7A32B86757C9FC78957A064744E500C0E70E4D"
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
    /// MedicalRecordGuest
    /// </summary>
    public partial class MedicalRecordGuest : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\..\View\MedicalRecordGuest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox umcnText;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\View\MedicalRecordGuest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox bloodTypeComboBox;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\View\MedicalRecordGuest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addAllergiesButton;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\View\MedicalRecordGuest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button savePatientButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Sims-Hospital;component/view/medicalrecordguest.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\MedicalRecordGuest.xaml"
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
            this.umcnText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.bloodTypeComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.addAllergiesButton = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\View\MedicalRecordGuest.xaml"
            this.addAllergiesButton.Click += new System.Windows.RoutedEventHandler(this.AddAllergiesButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.savePatientButton = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\..\View\MedicalRecordGuest.xaml"
            this.savePatientButton.Click += new System.Windows.RoutedEventHandler(this.SavePatientButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

