using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientsWebApplication.Models;

namespace PatientsWebApplication.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PatientContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Patients.Any())
            {
                return;   // DB has been seeded
            }

            var patients = new Patient[]
            {
            new Patient{FirstName="Carson",LastName="Alexander", MiddleName="Mackenzie", Address="3023 W Stolley Park Rd, Grand Island, NE 68801", 
                PhoneNumber="0975555555", MedicalCardID=1234567890 },
            new Patient{FirstName="Meredith",LastName="Alonso", MiddleName="Jobeth", Address="321 E Fonner Park Rd, Grand Island, NE 68801",
                PhoneNumber="0971111111", MedicalCardID=1235567890},
            new Patient{FirstName="Arturo",LastName="Anand",MiddleName="Cruise", Address="124 N 13th St, Lincoln, NE 68508",
                PhoneNumber="0975553498", MedicalCardID=1236567890},
            new Patient{FirstName="Gytis",LastName="Barzdukas", MiddleName="Stuart", Address="136 N 14th St, Lincoln, NE 68508",
                PhoneNumber="0971679884", MedicalCardID=1237567890},
            new Patient{FirstName="Yan",LastName="Li", MiddleName="Charles", Address="313 N 13th St, Lincoln, NE 68508, USA",
                PhoneNumber="0976538907", MedicalCardID=1238567890},
            new Patient{FirstName="Peggy",LastName="Justice", MiddleName="Burton", Address="University of Nebraska-Lincoln, 12th and, R St, Lincoln, NE 68588, USA",
                PhoneNumber="0975672345", MedicalCardID=1239567890},
            new Patient{FirstName="Laura",LastName="Norman", MiddleName="Charles", Address="R79V+4X Linkoln, Nebraska, USA",
                PhoneNumber="0971236587", MedicalCardID=1230567890},
            new Patient{FirstName="Nino",LastName="Olivetto", MiddleName="Mackenzie", Address="1801 R St, Lincoln, NE 68508, USA",
                PhoneNumber="0974443434", MedicalCardID=1231567890}
            };
            foreach (Patient p in patients)
            {
                context.Patients.Add(p);
            }
            context.SaveChanges();

            var doctors = new Doctor[]
            {
            new Doctor{ FirstName="Olivia", LastName="Hoxha", MiddleName="Sophia"},
            new Doctor{ FirstName="Emma", LastName="Prifti", MiddleName="Amelia"},
            new Doctor{ FirstName="Ava", LastName="	Shehu", MiddleName="Isabella"},
            new Doctor{ FirstName="Charlotte", LastName="Dervishi", MiddleName="Mia"},
            new Doctor{ FirstName="Sophia", LastName="Gruber", MiddleName="Evelyn"},
            new Doctor{ FirstName="Amelia", LastName="Huber", MiddleName="Harper"},
            new Doctor{ FirstName="Liam", LastName="Bauer", MiddleName="William"},
            new Doctor{ FirstName="Noah", LastName="Müller", MiddleName="James"},
            new Doctor{ FirstName="Oliver", LastName="Pichler", MiddleName="Benjamin"},
            new Doctor{ FirstName="Elijah", LastName="	Lang", MiddleName="Lucas"}
            };
            foreach (Doctor d in doctors)
            {
                context.Doctors.Add(d);
            }
            context.SaveChanges();

            var diagnoses = new Diagnosis[]
            {
            new Diagnosis { Name="Hypertension", Description="Hypertension (HTN or HT), also known as high blood pressure (HBP), is a long-term medical condition in which the blood pressure in the arteries is persistently elevated. High blood pressure typically does not cause symptoms. Long-term high blood pressure, however, is a major risk factor for stroke, coronary artery disease, heart failure, atrial fibrillation, peripheral arterial disease, vision loss, chronic kidney disease, and dementia. High blood pressure is classified as primary (essential) hypertension or secondary hypertension. About 90–95% of cases are primary, defined as high blood pressure due to nonspecific lifestyle and genetic factors. Lifestyle factors that increase the risk include excess salt in the diet, excess body weight, smoking, and alcohol use. The remaining 5–10% of cases are categorized as secondary high blood pressure, defined as high blood pressure due to an identifiable cause, such as chronic kidney disease, narrowing of the kidney arteries, an endocrine disorder, or the use of birth control pills." },
            new Diagnosis { Name="Hyperlipidemia", Description="You call it high cholesterol. Your doctor calls it hyperlipidemia. Either way, it's a common problem. The term covers several disorders that result in extra fats, also known as lipids, in your blood. You can control some of its causes; but not all of them. Hyperlipidemia is treatable, but it's often a life-long condition. You'll need to watch what you eat and also exercise regularly.You might need to take a prescription medication, too. The goal is to lower the harmful cholesterol levels. Doing so can reduce your risk of heart disease, heart attack, stroke, and other problems." },
            new Diagnosis { Name="Diabetes", Description="Diabetes mellitus (DM), commonly known as just diabetes, is a group of metabolic disorders characterized by a high blood sugar level over a prolonged period of time. Symptoms often include frequent urination, increased thirst and increased appetite. If left untreated, diabetes can cause many health complications. Acute complications can include diabetic ketoacidosis, hyperosmolar hyperglycemic state, or death. Serious long-term complications include cardiovascular disease, stroke, chronic kidney disease, foot ulcers, damage to the nerves, damage to the eyes and cognitive impairment." },
            new Diagnosis { Name="Back pain", Description="Back pain is a common reason for absence from work and for seeking medical treatment. It can be uncomfortable and debilitating. It can result from injury, activity and some medical conditions. Back pain can affect people of any age, for different reasons. As people get older, the chance of developingTrusted Source lower back pain increases, due to factors such as previous occupation and degenerative disk disease. Lower back pain may be linked to the bony lumbar spine, discs between the vertebrae, ligaments around the spine and discs, spinal cord and nerves, lower back muscles, abdominal and pelvic internal organs, and the skin around the lumbar area." },
            new Diagnosis { Name="Anxiety", Description="Anxiety is an emotion characterized by an unpleasant state of inner turmoil, often accompanied by nervous behavior such as pacing back and forth, somatic complaints, and rumination. It includes subjectively unpleasant feelings of dread over anticipated events.[need quotation to verify/ Anxiety is a feeling of uneasiness and worry, usually generalized and unfocused as an overreaction to a situation that is only subjectively seen as menacing. It is often accompanied by muscular tension, restlessness, fatigue, inability to catch one's breath, tightness in the abdominal region, and problems in concentration. Anxiety is closely related to fear, which is a response to a real or perceived immediate threat; anxiety involves the expectation of future threat including dread. People facing anxiety may withdraw from situations which have provoked anxiety in the past." },
            new Diagnosis { Name="Obesity", Description="Obesity is a medical condition in which excess body fat has accumulated to an extent that it may have a negative effect on health. People are generally considered obese when their body mass index (BMI), a measurement obtained by dividing a person's weight by the square of the person's height—despite known allometric inaccuracies[a]—is over 30 kg/m2; the range 25–30 kg/m2 is defined as overweight. Some East Asian countries use lower values.[10] Obesity is correlated with various diseases and conditions, particularly cardiovascular diseases, type 2 diabetes, obstructive sleep apnea, certain types of cancer, and osteoarthritis. High BMI is a marker of risk, but not proven to be a direct cause, for diseases caused by diet, physical activity, and environmental factors. A reciprocal link has been found between obesity and depression, with obesity increasing the risk of clinical depression and also depression leading to a higher chance of developing obesity." },
            new Diagnosis { Name="Allergic rhinitis", Description="An allergen is an otherwise harmless substance that causes an allergic reaction. Allergic rhinitis, or hay fever, is an allergic response to specific allergens. Pollen is the most common allergen in seasonal allergic rhinitis. These are allergy symptoms that occur with the change of seasons. Nearly 8 percent of adults in the United States experience allergic rhinitis of some kind, according to the American Academy of Allergy, Asthma & Immunology (AAAAI). Between 10 and 30 percent of the worldwide population may also have allergic rhinitis." },
            new Diagnosis { Name="Reflux esophagitis", Description="Esophagitis (uh-sof-uh-JIE-tis) is inflammation that may damage tissues of the esophagus, the muscular tube that delivers food from your mouth to your stomach. Esophagitis can cause painful, difficult swallowing and chest pain. Causes of esophagitis include stomach acids backing up into the esophagus, infection, oral medications and allergies. Treatment for esophagitis depends on the underlying cause and the severity of tissue damage.If left untreated, esophagitis can damage the lining of the esophagus and interfere with its normal function, which is to move food and liquid from your mouth to your stomach.Esophagitis can also lead to complications such as scarring or narrowing of the esophagus, and difficulty swallowing." },
            new Diagnosis { Name="Respiratory problems", Description="Allergies, asthma, inflammation, and infection are just some of the conditions that can cause you to have breathing problems. The right diagnosis and treatment, along with better understanding of your condition, can help you manage your breathing problems. Talk to your doctor right away anytime you notice problems with breathing -- especially if you also have symptoms like chest pain, a long-lasting cough, or fatigue." },
            new Diagnosis { Name="Hypothyroidism", Description="Hypothyroidism (underactive thyroid) is a condition in which your thyroid gland doesn't produce enough of certain crucial hormones. Hypothyroidism may not cause noticeable symptoms in the early stages. Over time, untreated hypothyroidism can cause a number of health problems, such as obesity, joint pain, infertility and heart disease. Accurate thyroid function tests are available to diagnose hypothyroidism. Treatment with synthetic thyroid hormone is usually simple, safe and effective once you and your doctor find the right dose for you." },
            };
            foreach (Diagnosis d in diagnoses)
            {
                context.Diagnoses.Add(d);
            }
            context.SaveChanges();

            var visits = new Visit[] { 
            new Visit { VisitDateTime=new DateTime(2021, 29, 10, 13, 58, 34), DoctorID=2, PatientID=1, DiagnosisID=1 },
            new Visit { VisitDateTime=new DateTime(2021, 30, 11, 15, 58, 34), DoctorID=3, PatientID=2 },
            new Visit { VisitDateTime=new DateTime(2021, 29, 10, 14, 58, 34), DoctorID=4, PatientID=3, DiagnosisID=2 },
            new Visit { VisitDateTime=new DateTime(2021, 29, 9, 7, 58, 34), DoctorID=1, PatientID=4 },
            new Visit { VisitDateTime=new DateTime(2021, 29, 9, 9, 58, 34), DoctorID=2, PatientID=5, DiagnosisID=3 },
            new Visit { VisitDateTime=new DateTime(2021, 29, 9, 19, 58, 34), DoctorID=3, PatientID=6 },
            new Visit { VisitDateTime=new DateTime(2021, 29, 9, 10, 58, 34), DoctorID=4, PatientID=7, DiagnosisID=4 },
            new Visit { VisitDateTime=new DateTime(2021, 29, 10, 11, 58, 34), DoctorID=1, PatientID=8 },
            new Visit { VisitDateTime=new DateTime(2021, 29, 11, 13, 58, 34), DoctorID=5, PatientID=1, DiagnosisID=5 },
            new Visit { VisitDateTime=new DateTime(2021, 29, 10, 15, 58, 34), DoctorID=6, PatientID=2 },
            new Visit { VisitDateTime=new DateTime(2021, 29, 9, 14, 58, 34), DoctorID=7, PatientID=3, DiagnosisID=6 },
            new Visit { VisitDateTime=new DateTime(2021, 29, 10, 10, 58, 34), DoctorID=8, PatientID=4 },
            };
            foreach (Visit v in visits)
            {
                context.Visits.Add(v);
            }
            context.SaveChanges();
        }
    }
}
