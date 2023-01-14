namespace Assignment_3B.Migrations
{
    using Assignment_3B.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment_3B.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Assignment_3B.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            try
            {
                // Add Photo Id Types
                AddPhotoIdTypes();

                // Add Certificate Types
                AddCertificateTypes();

                // Add Gender Types
                AddGenderTypes();

                // Add Some Candidates
                AddCandidates();

                // Add Some Exams And Certificates / A Certificate Is Created Only When the exam is successfull
                AddExamsAndCertificates();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            void AddPhotoIdTypes()
            {
                try
                {
                    if (context.PhotoIdTypes.Where(t => t.Type == "National Card").Count() == 0 &&
                        context.PhotoIdTypes.Where(t => t.Type == "Passport").Count() == 0)
                    {
                        context.PhotoIdTypes.Add(new PhotoIdType { Type = "National Card" });
                        context.PhotoIdTypes.Add(new PhotoIdType { Type = "Passport" });
                        context.SaveChanges();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Something not working with AddPhotoIdTypes Method!");
                }
            }

            void AddCertificateTypes()
            {
                try
                {
                    if (context.CertificateTypes.Where(t => t.Type == "Java").Count() == 0 &&
                        context.CertificateTypes.Where(t => t.Type == "C#").Count() == 0 &&
                        context.CertificateTypes.Where(t => t.Type == "Javascript").Count() == 0 &&
                        context.CertificateTypes.Where(t => t.Type == "Python").Count() == 0 &&
                        context.CertificateTypes.Where(t => t.Type == "C++").Count() == 0 &&
                        context.CertificateTypes.Where(t => t.Type == "SDS Foundation").Count() == 0 &&
                        context.CertificateTypes.Where(t => t.Type == "SDS Advanced").Count() == 0)
                    {
                        context.CertificateTypes.Add(new CertificateType { Type = "Java", IsActive = true });
                        context.CertificateTypes.Add(new CertificateType { Type = "C#", IsActive = true });
                        context.CertificateTypes.Add(new CertificateType { Type = "Javascript", IsActive = false });
                        context.CertificateTypes.Add(new CertificateType { Type = "Python", IsActive = true });
                        context.CertificateTypes.Add(new CertificateType { Type = "C++", IsActive = false });
                        context.CertificateTypes.Add(new CertificateType { Type = "SDS Foundation", IsActive = true });
                        context.CertificateTypes.Add(new CertificateType { Type = "SDS Advanced", IsActive = true });
                        context.SaveChanges();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Something not working with AddCertificateTypes Method!");
                }
            }

            void AddGenderTypes()
            {
                try
                {
                    if (context.Genders.Where(t => t.GenderType == "Female").Count() == 0 &&
                        context.Genders.Where(t => t.GenderType == "Male").Count() == 0 &&
                        context.Genders.Where(t => t.GenderType == "Prefer not to say").Count() == 0 &&
                        context.Genders.Where(t => t.GenderType == "Other").Count() == 0)
                    {
                        context.Genders.Add(new Gender { GenderType = "Female" });
                        context.Genders.Add(new Gender { GenderType = "Male" });
                        context.Genders.Add(new Gender { GenderType = "Prefer not to say" });
                        context.Genders.Add(new Gender { GenderType = "Other" });
                        context.SaveChanges();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Something not working with AddGenderTypes Method!");
                }
            }

            void AddCandidates()
            {
                try
                {
                    if (context.Candidates.Where(id => id.CandidateId == 1).Count() == 0 &&
                        context.Candidates.Where(id => id.CandidateId == 2).Count() == 0 &&
                        context.Candidates.Where(id => id.CandidateId == 3).Count() == 0 &&
                        context.Candidates.Where(id => id.CandidateId == 4).Count() == 0 &&
                        context.Candidates.Where(id => id.CandidateId == 5).Count() == 0 &&
                        context.Candidates.Where(id => id.CandidateId == 6).Count() == 0 &&
                        context.Candidates.Where(id => id.CandidateId == 7).Count() == 0 &&
                        context.Candidates.Where(id => id.CandidateId == 8).Count() == 0 &&
                        context.Candidates.Where(id => id.CandidateId == 9).Count() == 0 &&
                        context.Candidates.Where(id => id.CandidateId == 10).Count() == 0)
                    {
                        var genderMale = context.Genders.Where(x => x.GenderType == "Male").SingleOrDefault();
                        var genderFemale = context.Genders.Where(x => x.GenderType == "Female").SingleOrDefault();
                        var idTypeNationalCard = context.PhotoIdTypes.Where(x => x.Type == "National Card").SingleOrDefault();
                        var idTypePassport = context.PhotoIdTypes.Where(x => x.Type == "Passport").SingleOrDefault();

                        context.Candidates.Add(new Candidate
                        {
                            FirstName = "Alexandros",
                            MiddleName = "Nikolaos",
                            LastName = "Lepeniotis",
                            Gender = genderMale,
                            NativeLanguage = "Greek",
                            BirthDate = new DateTime(1992, 02, 02),
                            PhotoIdType = idTypeNationalCard,
                            PhotoIdNumber = "AA 123456",
                            PhotoIssueDate = new DateTime(2009, 01, 01),
                            Email = "alex@alex.com",
                            AddressLine = "Korai 5",
                            AddressLine2 = "2nd Floor",
                            CountryOfResidence = "Greece",
                            Province = "Attiki",
                            City = "Athens",
                            PostalCode = "12345",
                            LandlineNumber = "+302109090999",
                            MobileNumber = "+306912345678"
                        });
                        context.Candidates.Add(new Candidate
                        {
                            FirstName = "Mpampis",
                            LastName = "Papadimitriou",
                            Gender = genderMale,
                            NativeLanguage = "Greek",
                            BirthDate = new DateTime(1998, 01, 01),
                            PhotoIdType = idTypeNationalCard,
                            PhotoIdNumber = "AB 999999",
                            PhotoIssueDate = new DateTime(2015, 05, 05),
                            Email = "mpa@mpampis.com",
                            AddressLine = "Axeloou 7",
                            AddressLine2 = "Ground Floor",
                            CountryOfResidence = "Greece",
                            Province = "Thessaloniki",
                            City = "Kalamaria",
                            PostalCode = "12345",
                            LandlineNumber = "+30231009090",
                            MobileNumber = "+306912345678"
                        });
                        context.Candidates.Add(new Candidate
                        {
                            FirstName = "Kostas",
                            LastName = "Kostopoulos",
                            Gender = genderMale,
                            NativeLanguage = "Greek",
                            BirthDate = new DateTime(1980, 05, 12),
                            PhotoIdType = idTypeNationalCard,
                            PhotoIdNumber = "AH 111111",
                            PhotoIssueDate = new DateTime(2015, 09, 25),
                            Email = "kostas@kostopoulos.com",
                            AddressLine = "Pentelis 2",
                            AddressLine2 = "4th Floor",
                            CountryOfResidence = "Greece",
                            Province = "Attiki",
                            City = "Athens",
                            PostalCode = "54321",
                            LandlineNumber = "+302108888888",
                            MobileNumber = "+306945454545"
                        });
                        context.Candidates.Add(new Candidate
                        {
                            FirstName = "Maria",
                            MiddleName = "Eleni",
                            LastName = "Papadopoulou",
                            Gender = genderFemale,
                            NativeLanguage = "Greek",
                            BirthDate = new DateTime(1972, 12, 12),
                            PhotoIdType = idTypePassport,
                            PhotoIdNumber = "AHQ4567FG",
                            PhotoIssueDate = new DateTime(2022, 10, 10),
                            Email = "maria-eleni@papadopoulou.com",
                            AddressLine = "Markou Mpotsari 67",
                            AddressLine2 = "1st Floor",
                            CountryOfResidence = "Greece",
                            Province = "Attiki",
                            City = "Athens",
                            PostalCode = "23456",
                            LandlineNumber = "+3021000000",
                            MobileNumber = "+306989898809"
                        });
                        context.Candidates.Add(new Candidate
                        {
                            FirstName = "Giannis",
                            MiddleName = "Marios",
                            LastName = "Papantoniou",
                            Gender = genderMale,
                            NativeLanguage = "Greek",
                            BirthDate = new DateTime(1970, 05, 12),
                            PhotoIdType = idTypeNationalCard,
                            PhotoIdNumber = "BA 989898",
                            PhotoIssueDate = new DateTime(2020, 05, 17),
                            Email = "giannis@papanto.com",
                            AddressLine = "Zagoriou 54",
                            AddressLine2 = "Ground Floor",
                            CountryOfResidence = "Greece",
                            Province = "Axaia",
                            City = "Patra",
                            PostalCode = "09899",
                            LandlineNumber = "+302908567893",
                            MobileNumber = "+306932323232"
                        });
                        context.Candidates.Add(new Candidate
                        {
                            FirstName = "Marios",
                            LastName = "Konstantinou",
                            Gender = genderMale,
                            NativeLanguage = "Greek",
                            BirthDate = new DateTime(1999, 02, 03),
                            PhotoIdType = idTypePassport,
                            PhotoIdNumber = "AZX09DF45",
                            PhotoIssueDate = new DateTime(2022, 01, 21),
                            Email = "marios@konstantinou.com",
                            AddressLine = "Koukounarias 28",
                            AddressLine2 = "3rd Floor",
                            CountryOfResidence = "Greece",
                            Province = "Attiki",
                            City = "Zografou",
                            PostalCode = "33321",
                            LandlineNumber = "+3021045678677",
                            MobileNumber = "+306900806754"
                        });
                        context.Candidates.Add(new Candidate
                        {
                            FirstName = "Eleni",
                            MiddleName = "Giota",
                            LastName = "Kakavia",
                            Gender = genderFemale,
                            NativeLanguage = "Greek",
                            BirthDate = new DateTime(1999, 01, 11),
                            PhotoIdType = idTypeNationalCard,
                            PhotoIdNumber = "AA 345678",
                            PhotoIssueDate = new DateTime(2018, 01, 10),
                            Email = "giota@kakavia.com",
                            AddressLine = "Parou 33",
                            AddressLine2 = "1th Floor",
                            CountryOfResidence = "Greece",
                            Province = "Attiki",
                            City = "Zografou",
                            PostalCode = "67678",
                            LandlineNumber = "+30210983425",
                            MobileNumber = "+306978463300"
                        });
                        context.Candidates.Add(new Candidate
                        {
                            FirstName = "Alexia",
                            LastName = "Zoumpouri",
                            Gender = genderFemale,
                            NativeLanguage = "Greek",
                            BirthDate = new DateTime(2000, 01, 02),
                            PhotoIdType = idTypeNationalCard,
                            PhotoIdNumber = "AK 345267",
                            PhotoIssueDate = new DateTime(2017, 09, 10),
                            Email = "alexia@zoumpou.com",
                            AddressLine = "Parnithas 22",
                            AddressLine2 = "3th Floor",
                            CountryOfResidence = "Greece",
                            Province = "Attiki",
                            City = "Ano Liosia",
                            PostalCode = "34546",
                            LandlineNumber = "+30219080777",
                            MobileNumber = "+306945673211"
                        });
                        context.Candidates.Add(new Candidate
                        {
                            FirstName = "Pinelopi",
                            MiddleName = "Dafni",
                            LastName = "Karaiskou",
                            Gender = genderFemale,
                            NativeLanguage = "Greek",
                            BirthDate = new DateTime(1987, 03, 03),
                            PhotoIdType = idTypePassport,
                            PhotoIdNumber = "QQ4445GF",
                            PhotoIssueDate = new DateTime(2021, 11, 04),
                            Email = "dafni_pin@kara.com",
                            AddressLine = "Spartis 99",
                            AddressLine2 = "Ground Floor",
                            CountryOfResidence = "Greece",
                            Province = "Axaia",
                            City = "Kalamata",
                            PostalCode = "669077",
                            LandlineNumber = "+302107878666",
                            MobileNumber = "+306967458933"
                        });
                        context.Candidates.Add(new Candidate
                        {
                            FirstName = "Hercules",
                            MiddleName = "John",
                            LastName = "Williams",
                            Gender = genderMale,
                            NativeLanguage = "English",
                            BirthDate = new DateTime(1960, 12, 03),
                            PhotoIdType = idTypePassport,
                            PhotoIdNumber = "FFF3456DQSA",
                            PhotoIssueDate = new DateTime(2020, 04, 01),
                            Email = "herc@williams.com",
                            AddressLine = "Dodekanisou 77",
                            AddressLine2 = "2nd Floor",
                            CountryOfResidence = "Greece",
                            Province = "Attiki",
                            City = "Drosia",
                            PostalCode = "99887",
                            LandlineNumber = "+302108877669",
                            MobileNumber = "+306934556788"
                        });
                        context.SaveChanges();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Something not working with AddCandidate Method!");
                }
            }

            void AddExamsAndCertificates()
            {
                try
                {
                    if (context.Certificates.Where(x => x.CertificateId == 1).Count() == 0)
                    {
                        // Succeeded Exam with Certificate
                        var exam1 = new Exam(context.Candidates.Where(c => c.CandidateId == 2).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "Java").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 20,
                                MarkOfTopic2 = 10,
                                MarkOfTopic3 = 20,
                                MarkOfTopic4 = 20
                            });

                        context.Certificates.Add(new Certificate
                        {
                            CertificateType = exam1.CertificateType,
                            CandidateId = context.Candidates.Where(c => c.CandidateId == 2).SingleOrDefault(),
                            AssessmentTestCode = "AWW 345622",
                            ExaminationDate = new DateTime(2020, 04, 22),
                            ScoreReportDate = new DateTime(2020, 04, 30),
                            Exam = exam1,
                            CandidateScore = exam1.FinalScore,
                            TopicDescription = "Java Certificate",
                            NumberOfAwardedMarks = 0,
                            NumberOfPossibleMakrs = 1
                        });

                        // A Failed Exam that did not lead to a Certificate
                        var exam2 = new Exam(context.Candidates.Where(c => c.CandidateId == 2).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "SDS Foundation").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 10,
                                MarkOfTopic2 = 10,
                                MarkOfTopic3 = 15,
                                MarkOfTopic4 = 20
                            });
                        context.Exams.Add(exam2);

                        // Succeeded Exam with Certificate
                        var exam3 = new Exam(context.Candidates.Where(c => c.CandidateId == 6).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "C#").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 20,
                                MarkOfTopic2 = 15,
                                MarkOfTopic3 = 25,
                                MarkOfTopic4 = 30
                            });

                        context.Certificates.Add(new Certificate
                        {
                            CertificateType = exam3.CertificateType,
                            CandidateId = context.Candidates.Where(c => c.CandidateId == 6).SingleOrDefault(),
                            AssessmentTestCode = "CSF 659039",
                            ExaminationDate = new DateTime(2019, 08, 04),
                            ScoreReportDate = new DateTime(2019, 08, 30),
                            Exam = exam3,
                            CandidateScore = exam3.FinalScore,
                            TopicDescription = "C# Certificate",
                            NumberOfAwardedMarks = 1,
                            NumberOfPossibleMakrs = 0
                        });

                        // A Failed Exam that did not lead to a Certificate
                        var exam4 = new Exam(context.Candidates.Where(c => c.CandidateId == 6).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "Python").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 10,
                                MarkOfTopic2 = 10,
                                MarkOfTopic3 = 20,
                                MarkOfTopic4 = 20
                            });
                        context.Exams.Add(exam4);

                        // Succeeded Exam with Certificate
                        var exam5 = new Exam(context.Candidates.Where(c => c.CandidateId == 6).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "Java").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 20,
                                MarkOfTopic2 = 15,
                                MarkOfTopic3 = 25,
                                MarkOfTopic4 = 25
                            });

                        context.Certificates.Add(new Certificate
                        {
                            CertificateType = exam5.CertificateType,
                            CandidateId = context.Candidates.Where(c => c.CandidateId == 6).SingleOrDefault(),
                            AssessmentTestCode = "JVW 375488",
                            ExaminationDate = new DateTime(2019, 08, 04),
                            ScoreReportDate = new DateTime(2019, 09, 02),
                            Exam = exam5,
                            CandidateScore = exam5.FinalScore,
                            TopicDescription = "Java Certificate",
                            NumberOfAwardedMarks = 1,
                            NumberOfPossibleMakrs = 0
                        });


                        // Succeeded Exam with Certificate
                        var exam6 = new Exam(context.Candidates.Where(c => c.CandidateId == 8).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "SDS Foundation").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 20,
                                MarkOfTopic2 = 20,
                                MarkOfTopic3 = 30,
                                MarkOfTopic4 = 22
                            });

                        context.Certificates.Add(new Certificate
                        {
                            CertificateType = exam6.CertificateType,
                            CandidateId = context.Candidates.Where(c => c.CandidateId == 8).SingleOrDefault(),
                            AssessmentTestCode = "SDS 456834FND",
                            ExaminationDate = new DateTime(2018, 03, 11),
                            ScoreReportDate = new DateTime(2018, 03, 15),
                            Exam = exam6,
                            CandidateScore = exam6.FinalScore,
                            TopicDescription = "SDS Foundation Certificate",
                            NumberOfAwardedMarks = 1,
                            NumberOfPossibleMakrs = 0
                        });


                        // Succeeded Exam with Certificate
                        var exam7 = new Exam(context.Candidates.Where(c => c.CandidateId == 8).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "SDS Advanced").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 20,
                                MarkOfTopic2 = 15,
                                MarkOfTopic3 = 30,
                                MarkOfTopic4 = 22
                            });

                        context.Certificates.Add(new Certificate
                        {
                            CertificateType = exam7.CertificateType,
                            CandidateId = context.Candidates.Where(c => c.CandidateId == 8).SingleOrDefault(),
                            AssessmentTestCode = "SDS 338755ADV",
                            ExaminationDate = new DateTime(2018, 05, 17),
                            ScoreReportDate = new DateTime(2018, 05, 22),
                            Exam = exam7,
                            CandidateScore = exam7.FinalScore,
                            TopicDescription = "SDS Advanced Certificate",
                            NumberOfAwardedMarks = 1,
                            NumberOfPossibleMakrs = 0
                        });


                        // A Failed Exam that did not lead to a Certificate
                        var exam8 = new Exam(context.Candidates.Where(c => c.CandidateId == 10).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "Python").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 10,
                                MarkOfTopic2 = 15,
                                MarkOfTopic3 = 15,
                                MarkOfTopic4 = 10
                            });
                        context.Exams.Add(exam8);


                        // Succeeded Exam with Certificate
                        var exam9 = new Exam(context.Candidates.Where(c => c.CandidateId == 10).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "C#").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 20,
                                MarkOfTopic2 = 18,
                                MarkOfTopic3 = 30,
                                MarkOfTopic4 = 30
                            });

                        context.Certificates.Add(new Certificate
                        {
                            CertificateType = exam9.CertificateType,
                            CandidateId = context.Candidates.Where(c => c.CandidateId == 10).SingleOrDefault(),
                            AssessmentTestCode = "CSJ 339022",
                            ExaminationDate = new DateTime(2022, 03, 22),
                            ScoreReportDate = new DateTime(2022, 03, 29),
                            Exam = exam9,
                            CandidateScore = exam9.FinalScore,
                            TopicDescription = "C# Certificate",
                            NumberOfAwardedMarks = 1,
                            NumberOfPossibleMakrs = 0
                        });


                        // Succeeded Exam with Certificate
                        var exam10 = new Exam(context.Candidates.Where(c => c.CandidateId == 4).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "SDS Foundation").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 13,
                                MarkOfTopic2 = 20,
                                MarkOfTopic3 = 20,
                                MarkOfTopic4 = 30
                            });

                        context.Certificates.Add(new Certificate
                        {
                            CertificateType = exam10.CertificateType,
                            CandidateId = context.Candidates.Where(c => c.CandidateId == 4).SingleOrDefault(),
                            AssessmentTestCode = "SDS 943543FND",
                            ExaminationDate = new DateTime(2015, 07, 12),
                            ScoreReportDate = new DateTime(2015, 07, 20),
                            Exam = exam10,
                            CandidateScore = exam10.FinalScore,
                            TopicDescription = "SDS Foundation Certificate",
                            NumberOfAwardedMarks = 0,
                            NumberOfPossibleMakrs = 0
                        });


                        // A Failed Exam that did not lead to a Certificate
                        var exam11 = new Exam(context.Candidates.Where(c => c.CandidateId == 4).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "SDS Advanced").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 12,
                                MarkOfTopic2 = 5,
                                MarkOfTopic3 = 15,
                                MarkOfTopic4 = 30
                            });
                        context.Exams.Add(exam11);


                        // Succeeded Exam with Certificate
                        var exam12 = new Exam(context.Candidates.Where(c => c.CandidateId == 1).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "SDS Foundation").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 20,
                                MarkOfTopic2 = 10,
                                MarkOfTopic3 = 20,
                                MarkOfTopic4 = 20
                            });

                        context.Certificates.Add(new Certificate
                        {
                            CertificateType = exam12.CertificateType,
                            CandidateId = context.Candidates.Where(c => c.CandidateId == 1).SingleOrDefault(),
                            AssessmentTestCode = "SDS 458739FND",
                            ExaminationDate = new DateTime(2022, 02, 10),
                            ScoreReportDate = new DateTime(2022, 02, 15),
                            Exam = exam12,
                            CandidateScore = exam12.FinalScore,
                            TopicDescription = "SDS Foundation Certificate",
                            NumberOfAwardedMarks = 0,
                            NumberOfPossibleMakrs = 0
                        });


                        // Succeeded Exam with Certificate
                        var exam13 = new Exam(context.Candidates.Where(c => c.CandidateId == 1).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "Python").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 20,
                                MarkOfTopic2 = 20,
                                MarkOfTopic3 = 15,
                                MarkOfTopic4 = 25
                            });

                        context.Certificates.Add(new Certificate
                        {
                            CertificateType = exam13.CertificateType,
                            CandidateId = context.Candidates.Where(c => c.CandidateId == 1).SingleOrDefault(),
                            AssessmentTestCode = "PYS 993211",
                            ExaminationDate = new DateTime(2020, 01, 10),
                            ScoreReportDate = new DateTime(2020, 01, 13),
                            Exam = exam13,
                            CandidateScore = exam13.FinalScore,
                            TopicDescription = "Python Certificate",
                            NumberOfAwardedMarks = 0,
                            NumberOfPossibleMakrs = 0
                        });


                        // Succeeded Exam with Certificate
                        var exam14 = new Exam(context.Candidates.Where(c => c.CandidateId == 9).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "Java").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 20,
                                MarkOfTopic2 = 18,
                                MarkOfTopic3 = 20,
                                MarkOfTopic4 = 30
                            });

                        context.Certificates.Add(new Certificate
                        {
                            CertificateType = exam14.CertificateType,
                            CandidateId = context.Candidates.Where(c => c.CandidateId == 9).SingleOrDefault(),
                            AssessmentTestCode = "JVW 889230",
                            ExaminationDate = new DateTime(2014, 05, 13),
                            ScoreReportDate = new DateTime(2014, 05, 18),
                            Exam = exam14,
                            CandidateScore = exam14.FinalScore,
                            TopicDescription = "Java Certificate",
                            NumberOfAwardedMarks = 1,
                            NumberOfPossibleMakrs = 0
                        });


                        // Succeeded Exam with Certificate
                        var exam15 = new Exam(context.Candidates.Where(c => c.CandidateId == 5).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "Python").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 20,
                                MarkOfTopic2 = 20,
                                MarkOfTopic3 = 30,
                                MarkOfTopic4 = 20
                            });

                        context.Certificates.Add(new Certificate
                        {
                            CertificateType = exam15.CertificateType,
                            CandidateId = context.Candidates.Where(c => c.CandidateId == 5).SingleOrDefault(),
                            AssessmentTestCode = "PYT 998435",
                            ExaminationDate = new DateTime(2018, 04, 04),
                            ScoreReportDate = new DateTime(2018, 04, 09),
                            Exam = exam15,
                            CandidateScore = exam15.FinalScore,
                            TopicDescription = "Python Certificate",
                            NumberOfAwardedMarks = 1,
                            NumberOfPossibleMakrs = 0
                        });


                        // A Failed Exam that did not lead to a Certificate
                        var exam16 = new Exam(context.Candidates.Where(c => c.CandidateId == 7).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "Python").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 12,
                                MarkOfTopic2 = 10,
                                MarkOfTopic3 = 20,
                                MarkOfTopic4 = 10
                            });
                        context.Exams.Add(exam16);


                        // A Failed Exam that did not lead to a Certificate
                        var exam17 = new Exam(context.Candidates.Where(c => c.CandidateId == 7).SingleOrDefault(),
                            context.CertificateTypes.Where(c => c.Type == "C#").SingleOrDefault(),
                            new MarkPerTopic()
                            {
                                MarkOfTopic1 = 10,
                                MarkOfTopic2 = 5,
                                MarkOfTopic3 = 25,
                                MarkOfTopic4 = 20
                            });
                        context.Exams.Add(exam17);

                        context.SaveChanges();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Something not working with AddExamsAndCertificates Method!");
                }
            }
        }
    }
}
