import { useState } from 'react';
import { eliminar, Guardar, PostVideo } from "../Helpers/Convertidor";
import { MostrarVideo } from './MostrarVideo';

export const App = () => {

    const [mostrarVideo, setMostrarVideo] = useState(false);
    const [GVideo, SetGVideo] = useState({});

    const ArrVideo = (event) => SetGVideo(event)

    const GuardarVideo = async () => await Guardar(GVideo)

    const TraerVideo = async () => {
        const traerData = await PostVideo();
        setMostrarVideo(true)
        setMostrarVideo(traerData);
    }

    const Eliminarcahe =  async () =>  await eliminar()


    return (

        <div className=" row justify-content-center my-5">

            <div className="col-6">
                <label className="form-label">Selecciona todos los archivos...</label>
                <input className="form-control" type="file" id="video" name="Video" onChange={(event) => ArrVideo(event.target.files[0])} accept=".mp4,.mp3" />
            </div>

            <div className="row button">
                <div className="col-6 d-flex justify-content-end">
                    <button className="btn btn-primary" onClick={GuardarVideo} >Cargar video</button>
                    <button className="btn btn-primary Mostar" onClick={TraerVideo} >Mostar video</button>
                    <button className="btn btn-primary " onClick={Eliminarcahe} >Eliminar cache</button>
                </div>
            </div>

              {mostrarVideo && <MostrarVideo url={ mostrarVideo} />}

        </div>
    )
}