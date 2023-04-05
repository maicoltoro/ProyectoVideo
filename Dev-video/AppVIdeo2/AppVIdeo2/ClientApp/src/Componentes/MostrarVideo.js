import { useState } from "react"
import { TraerVideo } from "../Helpers/Convertidor"
import { Videos } from "./Video"


export const MostrarVideo = ({ url }) => {

    let id = `${url[0].nombreVideo}-${url[0].fecha}`

    const [Video1, setVideo] = useState(false)

    const ReVIdeo = async (id) => {
        const solicitud = await TraerVideo(id);
        setVideo(true)
        setVideo(solicitud)
    }

    return (
        <>
            <div>
                <div className="Videos col-6">

                    {url.map((vide,index) => (
                        <div className="col-3" key={index}>
                            <div className="Contenedor">
                                <h3>{vide.nombreVideo}</h3>
                                <img src="../Imagenes/imagen2.png" id={id} onClick={(event) => ReVIdeo(event.currentTarget.id)}></img>
                            </div>
                        </div>

                    ))}
                </div>

                {Video1 && <Videos data={Video1} />}
            </div>
        </>
    )
}