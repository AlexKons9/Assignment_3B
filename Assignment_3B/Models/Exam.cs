using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3B.Models
{
    public class Exam
    {
        [Key]
        public int ExamsId { get; set; }
        public CertificateType CertificateType { get; set; }
        public Candidate CandidateId { get; set; }
        public MarkPerTopic MarkPerTopic { get; set; }
        public int FinalScore { get; set; }
        public string AssessmentTestResult { get; set; }


        public Exam()
        {

        }

        public Exam(Candidate candidateId, CertificateType certificateType, MarkPerTopic markPerTopic)
        {
            CandidateId = candidateId;
            CertificateType = certificateType;
            MarkPerTopic = markPerTopic;
            FinalScore = markPerTopic.MarkOfTopic1 + markPerTopic.MarkOfTopic2 + 
                         markPerTopic.MarkOfTopic3 + markPerTopic.MarkOfTopic4;
            if(FinalScore >= 65)
            {
                AssessmentTestResult = "Pass";
            }
            else
            {
                AssessmentTestResult = "Fail";
            }
        }   

        public override string ToString()
        {
            return $"ExamId: {ExamsId}\nCertificateType: {CertificateType.Type}\nCadidateId: {CandidateId.CandidateId}\n" +
                $"MarksPerTopicId: {MarkPerTopic.Id}\nFinalScore: {FinalScore}\nAssessmentTestResult: {AssessmentTestResult}";
        }
    }
}
