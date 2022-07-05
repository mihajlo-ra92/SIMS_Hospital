using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sims_Hospital.View
{
    /// <summary>
    /// Interaction logic for EvalueateHospitalPage.xaml
    /// </summary>
    public partial class EvalueateHospitalPage : Window
    {
        public Patient Patient;
        public BindingList<Question> Questions;
        public QuestionController questionController;
        public AnswerController answerController;
        public EvalueateHospitalPage(Patient patient)
        {
            InitializeComponent();
            var app = Application.Current as App;
            questionController = app.QuestionController;
            answerController = app.AnswerController;
            this.Patient = patient;

            InitializeLabelsAndComboBoxs();            
        }

        private List<int> InitializationGrades(List<int> grades)
        {
            for (int i = 0; i < 5; ++i)
            {
                grades.Add(i + 1);
            }
            return grades;
        }


        private void InitializeLabelsAndComboBoxs() 
        {
            List<Question> allQuestions = questionController.ReadAllForHospital();
            Questions = new BindingList<Question>(allQuestions);
            List<int> grades = InitializationGrades(new List<int>());
            InitializeStackPanels(allQuestions, grades);


        }

        private void InitializeStackPanels(List<Question> questions,List<int> grades)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                Question question = Questions[i];
                MakeLabel(question);
                MakeComboBox(grades);
            }
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
        private void Evaluate_Click(object sender, RoutedEventArgs e)
        {
           
            List<Question> allQuestions = questionController.ReadAllForHospital();
            List < Answer> answers = MakeAnswers(allQuestions);
            answerController.Create(answers);
            BackToPatientHomePage();
        }
        private void BackToPatientHomePage()
        {
            PatientHomePage patientHomePage = new PatientHomePage(Patient);
            patientHomePage.Show();
            this.Close();
        }
        private List<Answer> MakeAnswers(List<Question> questions)
        {
            List<Answer> answers = new List<Answer>();
            for (int i = 0; i < questions.Count; i++)
            {
                Question question = questions[i];
                ComboBox comboBox = (ComboBox)STK1.Children[i];
                int grade = (int)comboBox.SelectedValue;
                Answer answer = MakeAnswer(Patient, question, grade);
                answers.Add(answer);
            }
            return answers;
        }

        private Answer MakeAnswer(Patient patient, Question question, int grade)
        {
            Answer answer = new Answer()
            {
                Patient = Patient,
                Question = question,
                Grade = grade,
            };
            return answer;
        }
    }
}
