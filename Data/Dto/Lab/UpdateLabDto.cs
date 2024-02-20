namespace Dto.Lab
{
    public class UpdateLabDto
    {
        public int LabId { get; set; }
        public int LessonModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}