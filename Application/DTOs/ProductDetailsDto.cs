namespace Application;

public class ProductDetailsDto
{
  
    public string Name { get; set; }
    public string Matricule { get; set; }
    public Guid Slug { get;  set; }
    public DateTime Date_Create { get;  set; }
    public DateTime Date_Edit { get;  set; }

}
