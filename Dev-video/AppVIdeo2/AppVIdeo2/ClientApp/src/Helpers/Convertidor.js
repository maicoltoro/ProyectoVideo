import { Correcto, Fallo, VideoExiste } from "./SwalAlert";

const Controlador = '/api/video/';

//export const Guardar = async (video) => {

//    const Obj = new Object();
//    Obj.NombreVideo = video.name
//    Obj.Fecha = ''

//    //const formData = new FormData();
//    //formData.append(`archivo`, video, video.name)

//    const fileInput = document.querySelector('input[type="file"]');
//    const reader = new FileReader();

//    reader.readAsDataURL(fileInput.files[0]);

//    reader.onload = function () {
//        let archivoCodificado = reader.result.split(',')[1];
//        Obj.Url = archivoCodificado.toString()
//        debugger
//        fetch(`${Controlador}GuardarVideo`, {
//            method: 'POST',
//            headers: { "Content-Type": "application/json" },
//            body: JSON.stringify(Obj)
//        })
//            .then(response => response.text())
//            .then(data => {
//                if (data == "OK") {
//                    Correcto()
//                } else if (data == "cargado") {
//                    VideoExiste()
//                } else {
//                    Fallo()
//                }
//            })
//    };

//    //const reader = new FileReader();
//    //reader.readAsArrayBuffer(video);
//    //reader.onloadend = () => {
//    //    debugger
//    //    const videoContent = reader.result;
//    //    const blob = new Blob([videoContent], { type: video.type });
//    //    const videoUrl = URL.createObjectURL(blob);

//    //    Obj.Url = videoUrl
//    //    debugger
//    //    fetch(`${Controlador}GuardarVideo`, {
//    //        method: 'POST',

//    //        body: video
//    //    })
//    //        .then(response => response.text())
//    //        .then(data => {
//    //            if (data == "OK") {
//    //                Correcto()
//    //            } else if (data == "cargado") {
//    //                VideoExiste()
//    //            } else {
//    //                Fallo()
//    //            }
//    //        })
//    //}
//}


export const Guardar = async (video) => {

    var archivo = document.querySelector('input[type="file"]').files[0];
    var formData = new FormData();
    formData.append('postedVideo', video);
    //debugger
    //var blob2 = new Blob([video], { type: video.type });
    //let arr = {
    //    size: blob2.size,
    //    type: blob2.type
    //};

    //const reader = new FileReader();
    //reader.readAsArrayBuffer(video);
    //reader.onloadend = () => {
    //    debugger
    //    const videoContent = reader.result;
    //    const blob = new Blob([videoContent], { type: video.type });
    //    console.log(blob)
    //    const videoUrl = URL.createObjectURL(blob);
    //    console.log(videoUrl)
    //}


    fetch(`${Controlador}GuardarVideo?nombre= ${video.name}`, {
        method: 'POST',
       // headers: { "Content-Type": "application/json" },
        body: formData
    })
        .then(response => response.text())
        .then(data => {
            if (data == "OK") {
                Correcto()
            } else if (data == "cargado") {
                VideoExiste()
            } else {
                Fallo()
            }

        })
        .catch(error => console.error(error));
}

export const PostVideo = async () => {
    const peticion = await fetch(`${Controlador}TraerVideos`)
    const respuesta = await peticion.json();
    return respuesta;
}


export const TraerVideo = async (id) => {
    const peticion = await fetch(`${Controlador}Video?id=${id}`)
    const respuesta = await peticion.json();
    return respuesta;
}

export const eliminar = async () => {
    const peticion = await fetch(`${Controlador}Eliminar`)
    const respuesta = await peticion.text();
    if (respuesta == "OK") {
        Correcto();
    } else {
        Fallo()
    }
}

export const transformar = (obj) => {
    debugger

    const sizeBuffer = new ArrayBuffer(obj.Length);
    const sizeView = new DataView(sizeBuffer);
    sizeView.setInt32(0, true); // setInt32(offset, value, littleEndian)
    const blob3 = new Blob([new Uint8Array(sizeBuffer)], { type: obj.ContentType });


    const reader = new FileReader();
    reader.readAsArrayBuffer(blob3);
    reader.onloadend = () => {
        debugger
        const videoContent = reader.result;
        const blob = new Blob([videoContent], { type: blob3.type });
        const videoUrl = URL.createObjectURL(blob);
    }
}