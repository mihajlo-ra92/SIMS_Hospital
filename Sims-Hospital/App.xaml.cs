using Controller;
using FileHandler;
using Model;
using Repository;
using Service;
using Sims_Hospital.FileHandler;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Sims_Hospital
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public PatientController PatientController{ get; set; }
        
        public QuestionController QuestionController { get; set; }
        public MedicalRecordController MedicalRecordController { get; set; }
        public GuestMedicalRecordController GuestMedicalRecordController { get; set; }
        public AppointmentController AppointmentController { get; set; }
        public RoomController RoomController { get; set; }
        public DoctorController DoctorController { get; set; }
        public SpecialistController SpecialistController { get; set; }
        public UserController UserController { get; set; }
        public LoggedInController LoggedInController { get; set; }
        public ReportController ReportController { get; set; }
        public PrescriptionController PrescriptionController { get; set; }
        public MedicineController MedicineController { get; set; }
        public AllergiesController AllergiesController { get; set; }
        public UserNotificationController UserNotificationController { get; set; }
        public FreeDayController FreeDayController { get; set; }
        public MedicineNotificationController MedicineNotificationController { get; set; }

        public AnswerController AnswerController { get; set; }
        public AnswerForAppointmentController AnswerForAppointmentController { get; set; }
        public MaliciouslyPatientController MaliciouslyPatientController { get; set; }
        public InvalidationRequestController InvalidationRequestController { get; set; }
        public string LanguageCode { get; set; }
        public string ThemeCode { get; set; }
        public User User { get; set; }
        public App()
        {
            LanguageCode = "en";
            ThemeCode = "light";
            InitializeControllers();

        }

        private void InitializeControllers()
        {
            var patientFileHandler = new PatientFileHandler();
            var medicalFileHandler = new MedicalRecordFileHandler();
            var guestMedicalFileHandler = new GuestMedicalRecordFileHandler();
            var userFileHandler = new UserFileHandler();
            var loggedInFileHandler = new LoggedInUserFileHandler();
            var allergiesFileHandler = new AllergiesFileHandler();
            var userNotificationFileHandler = new NotificationFileHandler();
            var medicineFileHandler = new MedicineFileHandler();
            var freeDayFileHandler = new FreeDayFileHandler();
            var invalidationRequestFileHandler = new InvalidationRequestFileHandler();


            var patientRepository = new PatientRepository(patientFileHandler);
            var medicalRecordRepository = new MedicalRecordRepository(medicalFileHandler);
            var guestMedicalRecordRepository = new GuestMedicalRecordRepository(guestMedicalFileHandler);
            var appointmentRepository = new AppointmentRepository();
            var appointmentScheduleRepository = new AppointmentScheduleRepository();
            var roomRepository = new RoomRepository();
            var doctorRepository = new DoctorRepository();
            var specialistRepository = new SpecialistRepository();
            var userRepository = new UserRepository(userFileHandler);
            var loggedInRepository = new LoggedInRepository(loggedInFileHandler);
            var allergiesRepository = new AllergiesRepository(allergiesFileHandler);
            var prescriptionRepository = new PrescriptionRepository();
            var reportRepository = new ReportRepository();
            var userNotificationsRepository = new UserNotificationRepository(userNotificationFileHandler);
            var medicineRepository = new MedicineRepository();
            var freeDayRepository = new FreeDayRepository();
            var questionRepository = new QuestionRepository();
            var AnswerRepository = new AnswerRepository();
            var AnswerForAppointmentRepository = new AnswerForAppointmentRepository();
            var MaliciouslyPatientRepository = new MaliciouslyPatientRepository();
            var InvalidationRequestRepository = new InvalidationRequestRepository();

            var allergieService = new AllergiesService(allergiesRepository, medicineRepository);
            var patientService = new PatientService(patientRepository, guestMedicalRecordRepository, medicalRecordRepository, userRepository,
                prescriptionRepository, appointmentRepository);
            var medicalRecordService = new MedicalRecordService(medicalRecordRepository, patientRepository, allergiesRepository);
            var guestMedicalRecordService = new GuestMedicalRecordService(guestMedicalRecordRepository,
                patientService,allergieService);
            var userService = new UserService(userRepository);
            var roomService = new RoomService(roomRepository);
            var doctorService = new DoctorService(doctorRepository, userRepository);
            var specialistService = new SpecialistService(specialistRepository);
            var appointmentService = new AppointmentService(appointmentRepository, roomRepository, doctorRepository,
                patientRepository, reportRepository, prescriptionRepository, appointmentScheduleRepository);
            var medicineService = new MedicineService(medicineRepository);
            var freeDayService = new FreeDayService(freeDayRepository, doctorRepository, specialistRepository);
            var loggedInService = new LoggedInService(loggedInRepository, userService);
            var reportService = new ReportService(reportRepository, appointmentRepository);
            var prescriptionService = new PrescriptionService(prescriptionRepository, appointmentRepository, patientRepository);
            var userNotificationService = new UserNotificationService(userNotificationsRepository, loggedInService, userService);
            var questionService = new QuestionService(questionRepository);
            var answerService = new AnswerService(AnswerRepository);
            var AnswerForAppointmentService = new AnswerForAppointmentService(AnswerForAppointmentRepository);
            var MaliciouslyPatientService = new MaliciouslyPatientService(MaliciouslyPatientRepository);
            var InvalidationRequestService = new InvalidationRequestService(InvalidationRequestRepository, medicineRepository);

            PatientController = new PatientController(patientService);
            MedicalRecordController = new MedicalRecordController(medicalRecordService);
            GuestMedicalRecordController = new GuestMedicalRecordController(guestMedicalRecordService);
            AppointmentController = new AppointmentController(appointmentService);
            RoomController = new RoomController(roomService);
            DoctorController = new DoctorController(doctorService);
            SpecialistController = new SpecialistController(specialistService);
            UserController = new UserController(userService);
            LoggedInController = new LoggedInController(loggedInService);
            ReportController = new ReportController(reportService);
            PrescriptionController = new PrescriptionController(prescriptionService);
            AllergiesController = new AllergiesController(allergieService);
            UserNotificationController = new UserNotificationController(userNotificationService);
            MedicineController = new MedicineController(medicineService);
            FreeDayController = new FreeDayController(freeDayService);
            QuestionController = new QuestionController(questionService);
            AnswerController = new AnswerController(answerService);
            AnswerForAppointmentController = new AnswerForAppointmentController(AnswerForAppointmentService);
            MaliciouslyPatientController = new MaliciouslyPatientController(MaliciouslyPatientService);
            InvalidationRequestController = new InvalidationRequestController(InvalidationRequestService);
        }

        public static string GetProjectPath()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location
            .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        }
    }
}
