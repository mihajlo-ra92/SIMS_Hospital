   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   StrHome  
StrConfirm  StrHospitalName  StrBookAppointment  StrMedicines  StrFreeDays  StrReferPatient  
StrAccount  
StrEnglish 	 
StrSerbian 
 	StrLogOut  StrPassword  StrName  StrLastName  StrBirthDate  	StrGender  StrEdit  	StrDelete  StrSearchPatient  StrSearchRoom  StrAppointmentDate  StrAppointmentTime  StrAppointmentLenght  StrAppointmentKind  StrEmergency  StrRoomSchedule  StrPatientName  StrRoomName  StrRoomKind  StrSentFreeDayRequests  StrDecisionNote  StrRequestNote   StrNewRequest ! StrFrom 	" StrTo # StrFreeDayNote $ StrStart 
% StrEnd & StrRoom ' StrWriteReport ( StrSendReport ) StrMedicineControl * StrSearchMedicine + StrMedicineName , StrCode - StrValidity . StrIngredients / StrNote 0 StrInvalidateMedicine 1 StrAppointments 2 StrAppointmentType 3 StrSearchDoctor 4 StrDoctorName 5 StrSpecialisation 6 StrSearchAppointment 7 StrMedicalRecords 8 StrMedicalRecord 9 StrParentName : StrBloodType ; 
StrAddress < StrAllergies = StrAllergenName > StrEditAppointment ? 	StrReport @ StrSymptoms A StrWritePrescription B StrMedicine C StrTherapyStart D StrTimesADay E StrDaysOfTherapy F StrDark G StrLight H StrLogIn I StrUsername  �� 
TargetType J Home �� Property �� Value K Appointment L 	Medicines M FreeDays 	N Refer O 	MedRecord P Account �� Color Q 
ThemeColor R OppositeColor 
S Button �� 
TargetType �� Triggers P� Property P� Value 	T Label U 	TextBlock V TextBox W PasswordBox X ComboBox Y 
StackPanel Z CheckBox&    System.Windows.Controls.DataGrid [ DataGrid=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� BasedOn*  $System.Windows.Controls.DataGridCell \ ListBox�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      1system&clr-namespace:System;assembly=mscorlib  5      %�  &	        &	       &	 ?     &	 e     &	 �     &	 �     &	 �     &	 �     &	     &		 2    &	
 P    &	 q    &	 �    &	 �    &	 �    &	 �    &	 
    &	 (    &	 H    &	 r    &	 �    &	 �    &	 �    &	     &	 5    &	 Z    &	 �    &	 �    &	 �    &	 �    &	 %    &	 Q    &	  u    &	! �    &	" �    &	# �    &	$ �    &	%     &	& ,    &	' H    &	( q    &	) �    &	* �    &	+ �    &	,     &	- &    &	. G    &	/ g    &	0 �    &	1 �    &	2 �    &	3 �    &	4     &	5 ;    &	6 a    &	7 �    &	8 �    &	9 �    &	:     &	; &    &	< D    &	= d    &	> �    &	? �    &	@ �    &	A �    &	B 	    &	C 1	    &	D Z	    &	E �	    &	F �	    &	G �	    &	H �	    &	I 
    &	J >
    &	K �
    &	L �
    &	M +    &	N z    &	O �    &	P     &	Q g    &	R �    &	S �    &	T T    &	U �    &	V �    &	W \    &	X �    &	Y �    &	Z ?    &	[ �    '  x    7 '  �    &	\ `    ��5      Naslovna��6.   ��5      Potvrdi��60   ��5      Zdravo bolnica��6<   ��5      Zakaži Termin��6>   ��5      
Lekovi��61   ��5	      Slobodni dani��67   ��5
      Uputi pacijenta��6=   ��5      	Nalog��6.   ��5      Engleski��61   ��5      
Srpski��6/   ��5      	Odjavi se��61   ��5      
Šifra��6/   ��5      Ime��6)   ��5      Prezime��61   ��5      Datum rodjenja��69   ��5      Pol��6+   ��5      
Izmeni��6,   ��5      Izbriši��6/   ��5      Pretraga pacijenta��6A   ��5      Pretraga soba��69   ��5      Datum termina��6>   ��5      Vreme termina��6>   ��5      Duzina termina (minuti)��6J   ��5      Vrsta termina��6>   ��5      Hitan slučaj��67   ��5      Uvid u raspored soba��6B   ��5      Ime pacijenta��6:   ��5      Ime sobe��62   ��5       
Vrsta sobe��64   ��5!      $ Poslati zahtevi za slobodne dane��6U   ��5"      Obrazloženje odluke��6A   ��5#      Opis zahteva��69   ��5$      Novi zahtev��67   ��5%      Od:��6)   ��5&      do:��6'   ��5'      
Opis pauze��67   ��5(      Početak��6.   ��5)      Kraj��6)   ��5*      Soba��6*   ��5+      Napiši izveštaj��6<   ��5,      Pošalji izveštaj��6<   ��5-      Kontrola lekova��6@   ��5.      Pretraga lekova��6?   ��5/      
Naziv leka��68   ��50      Kod��6)   ��51      	Validnost��63   ��52      Sastojci��65   ��53      Beleška��6-   ��54      Invaliduj lek��6A   ��55      Termini��65   ��56      Vrsta termina��6>   ��57      Pretraga doktora��6>   ��58      Ime doktora��67   ��59      Specializacija��6>   ��5:      Pretraga termina��6C   ��5;      Zdravstveni kartoni��6C   ��5<      Zdravstevni karton��6A   ��5=      Ime roditelja��69   ��5>      Krvna grupa��66   ��5?      
Adresa��6/   ��5@      Alergije��63   ��5A      Naziv alergena��6<   ��5B      Izmeni termin��6>   ��5C      	Izveštaj��60   ��5D      Simptomi��62   ��5E      Napiši recept��6@   ��5F      Lek��6-   ��5G      Početak terapije��6>   ��5H       Koliko puta dnevno uzeti lek��6G   ��5I      Koliko dana uzimati lek��6F   ��5J      	Tamno��6+   ��5K      
Svetlo��6-   ��5L      Prijava��6.   ��5M      Korisničko ime��68   �� 5O      "  ��6   .�5P   
   ��  � ��$ 	-55 1 1 1q�6#   5Q      �� 5S      "  ��6   .�5T   
   ��  � ��$ 	-43 1 1 1q�6#   5U      �� 5W      "  ��6   .�5X   
   ��  � ��$ 	-62 1 1 1q�6#   5Y      �� 5[      "  ��6   .�5\   
   ��  � ��$ 	-43 1 1 1q�6#   5]      �� 5_      "  ��6   .�5`   
   ��  � ��$ 	-40 1 1 1q�6#   5a      �� 5c      "  ��6   .�5d   
   ��  � ��$ 	-30 1 1 1q�6#   5e      �� 5g      "  ��6   .�5h   
   ��  � ��$ 	-64 1 1 1q�6#   5i      �� 5k      $ Black��6   6$   �� 5l      $ White��6   6$   �� 5n      "  ��6   .�5o   
   ��  � �� �#3D3D3D6'   �� 5p   
    � ��
 �����6'   �� 5q   
    � �� 5r      �� 5s      " ��6"   .R�5t      �� #��z��6   
�������$��1q�6[   ._�5u      �� $��Center=�6+   $��Center=�6H   5v      5w      5y       5z   
   P� 5{       �@J�IsMouseOver$
 True��6-   . �5|      ��  � ��
 �����6/   5}      5      �� 5�      "  ��6   .�5�   
   ��  � ��
 �����6'   5�      �� 5�      "  ��6   .�5�   
   ��  � ��
 �����6'   5�      �� 5�      "  ��6   .�5�   
   ��  � �� �#3434346'   �� 5�   
    � ��
 �����6'   5�      �� 5�      "  G�6   .�5�   
   ��  � �� �#3434346'   �� 5�   
    � ��
 �����6'   5�      �� 5�      "  ��6   5�      �� 5�      "  ��6   .�5�   
   ��  � �� �#2323236'   5�      �� 5�      "  ��6   .�5�   
   ��  � ��
 �����6'   5�      �� 5�      "    6   .�5�   
   ��  � ��
 �����6'   �� 5�   
    � �� �#3434346'   �� 5�   
     �@  AlternatingRowBackground �#34343465   �� 5�   
    �@  RowBackground �#3434346*   5�      �� 5�      8   "   6E   .�5�   
   ��  � �� �#3434346'   5�      �� 5�      "   6    5�   
   P� 5�       �@ 
IsSelected$
 True��69   . �5�      ��  � �� �#6F6F6F6/   5�      5�      �� 5�      "  ��6   .�5�   
   ��  � ��
 �����6'   �� 5�   
    � �� �#3434346'   5�      5�      