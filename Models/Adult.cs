using System.Text.Json;

namespace Models {
public class Adult : Person {
    public enum JobTitles
    {
        Teacher,
        Engineer,
        Programmer,
        Captain,
        Driver,
        Superman,
        Pirate,
        Ninja,
        Fireman
    }
    public string JobTitle { get; set; }

    public override string ToString() {
        return JsonSerializer.Serialize(this);
    }

    public void Update(Adult toUpdate) {
        JobTitle = toUpdate.JobTitle;
        base.Update(toUpdate);
    }

}
}