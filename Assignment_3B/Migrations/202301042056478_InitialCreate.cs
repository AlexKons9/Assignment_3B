namespace Assignment_3B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        NativeLanguage = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        PhotoIdNumber = c.String(),
                        PhotoIssueDate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        AddressLine = c.String(),
                        AddressLine2 = c.String(),
                        CountryOfResidence = c.String(),
                        Province = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        LandlineNumber = c.String(),
                        MobileNumber = c.String(),
                        Gender_GenderId = c.Int(),
                        PhotoIdType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CandidateId)
                .ForeignKey("dbo.Genders", t => t.Gender_GenderId)
                .ForeignKey("dbo.PhotoIdTypes", t => t.PhotoIdType_Id)
                .Index(t => t.Gender_GenderId)
                .Index(t => t.PhotoIdType_Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        GenderType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.PhotoIdTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        CertificateId = c.Int(nullable: false, identity: true),
                        AssessmentTestCode = c.String(),
                        ExaminationDate = c.DateTime(nullable: false),
                        ScoreReportDate = c.DateTime(nullable: false),
                        CandidateScore = c.Int(nullable: false),
                        MaximumScore = c.Int(nullable: false),
                        PercentageScore = c.String(),
                        TopicDescription = c.String(),
                        NumberOfAwardedMarks = c.Int(nullable: false),
                        NumberOfPossibleMakrs = c.Int(nullable: false),
                        CandidateId_CandidateId = c.Int(nullable: false),
                        CertificateType_Id = c.Int(nullable: false),
                        Exam_ExamsId = c.Int(),
                    })
                .PrimaryKey(t => t.CertificateId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId_CandidateId, cascadeDelete: true)
                .ForeignKey("dbo.CertificateTypes", t => t.CertificateType_Id, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.Exam_ExamsId)
                .Index(t => t.CandidateId_CandidateId)
                .Index(t => t.CertificateType_Id)
                .Index(t => t.Exam_ExamsId);
            
            CreateTable(
                "dbo.CertificateTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamsId = c.Int(nullable: false, identity: true),
                        FinalScore = c.Int(nullable: false),
                        AssessmentTestResult = c.String(),
                        CandidateId_CandidateId = c.Int(nullable: false),
                        CertificateType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ExamsId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId_CandidateId, cascadeDelete: true)
                .ForeignKey("dbo.CertificateTypes", t => t.CertificateType_Id)
                .Index(t => t.CandidateId_CandidateId)
                .Index(t => t.CertificateType_Id);
            
            CreateTable(
                "dbo.MarkPerTopics",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        MarkOfTopic1 = c.Int(nullable: false),
                        MarkOfTopic2 = c.Int(nullable: false),
                        MarkOfTopic3 = c.Int(nullable: false),
                        MarkOfTopic4 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Certificates", "Exam_ExamsId", "dbo.Exams");
            DropForeignKey("dbo.MarkPerTopics", "Id", "dbo.Exams");
            DropForeignKey("dbo.Exams", "CertificateType_Id", "dbo.CertificateTypes");
            DropForeignKey("dbo.Exams", "CandidateId_CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.Certificates", "CertificateType_Id", "dbo.CertificateTypes");
            DropForeignKey("dbo.Certificates", "CandidateId_CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.Candidates", "PhotoIdType_Id", "dbo.PhotoIdTypes");
            DropForeignKey("dbo.Candidates", "Gender_GenderId", "dbo.Genders");
            DropIndex("dbo.MarkPerTopics", new[] { "Id" });
            DropIndex("dbo.Exams", new[] { "CertificateType_Id" });
            DropIndex("dbo.Exams", new[] { "CandidateId_CandidateId" });
            DropIndex("dbo.Certificates", new[] { "Exam_ExamsId" });
            DropIndex("dbo.Certificates", new[] { "CertificateType_Id" });
            DropIndex("dbo.Certificates", new[] { "CandidateId_CandidateId" });
            DropIndex("dbo.Candidates", new[] { "PhotoIdType_Id" });
            DropIndex("dbo.Candidates", new[] { "Gender_GenderId" });
            DropTable("dbo.MarkPerTopics");
            DropTable("dbo.Exams");
            DropTable("dbo.CertificateTypes");
            DropTable("dbo.Certificates");
            DropTable("dbo.PhotoIdTypes");
            DropTable("dbo.Genders");
            DropTable("dbo.Candidates");
        }
    }
}
