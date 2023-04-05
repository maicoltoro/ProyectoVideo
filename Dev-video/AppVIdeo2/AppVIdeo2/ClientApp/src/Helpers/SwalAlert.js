import Swal from 'sweetalert2'

export const Correcto = () => {
    Swal.fire('Se guardo bien')
}

export const Fallo = () => {
    Swal.fire('Sucedio un error')
}

export const VideoExiste = () => {
    Swal.fire('El video que tratas de cargar ya fue cargado')
}