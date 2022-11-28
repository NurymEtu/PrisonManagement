using PrisonManagementWebApp.Data;
using PrisonManagementWebApp.Models;

namespace PrisonManagementWebApp.Tools
{
    public class DataSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            var prisonerList = new List<Prisoner>
            {
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=1},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=2},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=3},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=4},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=5},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=6},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=7},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=8},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=9},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=10},
                 new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=11},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=12},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=13},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=14},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=15},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=16},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=17},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=18},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=19},
                new Prisoner(){Name=GenerateName(RandomNumber()),PrisonNumber=20},
            };

            var guards = new List<Guard>
            {
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
                new Guard(){Name=GenerateName(RandomNumber())},
            };

            var cams = new List<CameraLive>
            {
                new CameraLive(){ CamNumber="01"},
            };
            var cellList = new List<Cell>
            {
                new Cell() {CellNumber=1,
                Prisoners=new List<Prisoner>{ prisonerList[0], prisonerList[1] },
                Guards=new List<Guard>{guards[0],guards[1] },
                CameraLives=new List<CameraLive>{ cams[0] }, },
                new Cell() {CellNumber=2 ,
                Prisoners=new List<Prisoner>{ prisonerList[2], prisonerList[3] },
                Guards=new List<Guard>{guards[2],guards[3] },
                CameraLives=new List<CameraLive>{ cams[0] },},
                new Cell() {CellNumber=3 ,
                Prisoners=new List<Prisoner>{ prisonerList[4], prisonerList[5] },
                Guards=new List<Guard>{guards[4],guards[5] },
                CameraLives=new List<CameraLive>{ cams[0] },},
                new Cell() {CellNumber=4 ,
                Prisoners=new List<Prisoner>{ prisonerList[6], prisonerList[7] },
                Guards=new List<Guard>{guards[6],guards[7] },
                CameraLives=new List<CameraLive>{ cams[0] },},
                new Cell() {CellNumber=5 ,
                Prisoners=new List<Prisoner>{ prisonerList[8], prisonerList[9] },
                Guards=new List<Guard>{guards[8],guards[9] },
                CameraLives=new List<CameraLive>{ cams[0] },},
                new Cell() {CellNumber=6 ,
                Prisoners=new List<Prisoner>{ prisonerList[10], prisonerList[11] },
                Guards=new List<Guard>{guards[10],guards[11] },
                CameraLives=new List<CameraLive>{ cams[0] },},
                new Cell() {CellNumber=7 ,
                Prisoners=new List<Prisoner>{ prisonerList[12], prisonerList[13] },
                Guards=new List<Guard>{guards[12],guards[13] },
                CameraLives=new List<CameraLive>{ cams[0] },},
                new Cell() {CellNumber=8 ,
                Prisoners=new List<Prisoner>{ prisonerList[14], prisonerList[15] },
                Guards=new List<Guard>{guards[14],guards[15] },
                CameraLives=new List<CameraLive>{ cams[0] },},
                new Cell() {CellNumber=9 ,
                Prisoners=new List<Prisoner>{ prisonerList[16], prisonerList[17] },
                Guards=new List<Guard>{guards[16],guards[17] },
                CameraLives=new List<CameraLive>{ cams[0] },},
                new Cell() {CellNumber=10,
                Prisoners=new List<Prisoner>{ prisonerList[18], prisonerList[19] },
                Guards=new List<Guard>{guards[18],guards[19] },
                CameraLives=new List<CameraLive>{ cams[0] },},
            };
            var visitors=new List<Visitor>
            {
                 new Visitor{ Genger="Male",Name=GenerateName(RandomNumber())},
                new Visitor{ Genger="Male",Name=GenerateName(RandomNumber())},
                new Visitor{ Genger="Male",Name=GenerateName(RandomNumber())},
                new Visitor{ Genger="Male",Name=GenerateName(RandomNumber())},
                new Visitor{ Genger="Male",Name=GenerateName(RandomNumber())},
                new Visitor{ Genger="Male",Name=GenerateName(RandomNumber())},
                new Visitor{ Genger="Male",Name=GenerateName(RandomNumber())},
                new Visitor{ Genger="Male",Name=GenerateName(RandomNumber())},
                new Visitor{ Genger="Male",Name=GenerateName(RandomNumber())},
                new Visitor{ Genger="Male",Name=GenerateName(RandomNumber())},
                new Visitor{ Genger="Male",Name=GenerateName(RandomNumber())},
            };
            context.Visitors.AddRange(visitors);
            context.Cells.AddRange(cellList);
            context.SaveChanges();
        }

        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }
        public static int RandomNumber()
        {
            Random r = new Random();
            return r.Next(15);
        }
    }
}
