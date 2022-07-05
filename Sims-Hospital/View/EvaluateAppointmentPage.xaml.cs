using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Controller;
using Model;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace Sims_Hospital.View
{
    /// <summary>
    /// Interaction logic for EvaluateAppointmentPage.xaml
    /// </summary>
    public partial class EvaluateAppointmentPage : Window
    {
        public Appointment Appointment;
        public BindingList<Question> Questions;
        public QuestionController questionController;
        public AnswerForAppointmentController AnswerForAppointmentController;
        public EvaluateAppointmentPage(Appointment appointment)
        {
            InitializeComponent();
            Appointment = appointment;
            var app = Application.Current as App;
            questionController = app.QuestionController;
            AnswerForAppointmentController = app.AnswerForAppointmentController;
            InitializeLabelsAndComboBoxs();
        }

        private void InitializeLabelsAndComboBoxs()
        {
            List<Question> allQuestions = questionController.ReadAllForAppointmeent();
            Questions = new BindingList<Question>(allQuestions);
            List<int> grades = InitializationGrades(new List<int>());
            InitializeStackPanels(allQuestions, grades);
        }

        private void MakeLabel(Question question)
        {
            string questionText = question.QuestionText;
            Label lbl1 = new Label();
            lbl1.Content = questionText;
            STK.Children.Add(lbl1);
        }
        private void MakeComboBox(List<int> grades)
        {
            ComboBox comboBox = new ComboBox
            {
                ItemsSource = grades,
                Margin = new Thickness(2),
                DisplayMemberPath = "",
                SelectedIndex = 0
            };
            STK1.Children.Add(comboBox);
        }

        private void InitializeStackPanels(List<Question> questions, List<int> grades)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                Question question = Questions[i];
                MakeLabel(question);
                MakeComboBox(grades);
            }
        }

        private List<int> InitializationGrades(List<int> grades)
        {
            for (int i = 0; i < 5; ++i)
            {
                grades.Add(i + 1);
            }
            return grades;
        }

        private void Evaluate_Click(object sender, RoutedEventArgs e)
        {
            List<Question> allQuestions = questionController.ReadAllForAppointmeent();
            List<AnswerForAppointment> answers = MakeAnswers(allQuestions);
            AnswerForAppointmentController.Create(answers);

            BackToPatientHomePage();
        }
        private void BackToPatientHomePage()
        {
            PatientHomePage patientHomePage = new PatientHomePage(Appointment.Patient);
            patientHomePage.Show();
            this.Close();
        }

        private List<AnswerForAppointment> MakeAnswers(List<Question> allQuestions)
        {
            List<AnswerForAppointment> answers = new List<AnswerForAppointment>();

            for (int i = 0; i < allQuestions.Count; i++)
            {
                Question question = allQuestions[i];
                ComboBox comboBox = (ComboBox)STK1.Children[i];
                int grade = (int)comboBox.SelectedValue;
                AnswerForAppointment answer = MakeAnswer(question,grade);
                answers.Add(answer);
            }
            return answers;

        }

        private AnswerForAppointment MakeAnswer(Question question, int grade)
        {
            AnswerForAppointment answer = new AnswerForAppointment()
            {
                Appointment = Appointment,
                Question = question,
                Grade = grade,
            };
            return answer;
        }
    }
}
