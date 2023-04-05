using ApiVideo.Context;
using ApiVideo.Models.STI;

namespace ApiVideo.Clases
{
    public class Videos
    {
        public List<GuardarVideo> traerVideo()
        {
            using (CrudJuniorContext con = new CrudJuniorContext())
            {
                var data = con.GuardarVideos.ToList();
                return data;
            }
        }

        public string Guardar(GuardarVideo data)
        {
            using (CrudJuniorContext con = new CrudJuniorContext())
            {
                con.GuardarVideos.Add(data);
                con.SaveChanges();
                return "OK";
            }
        }

    }
}
