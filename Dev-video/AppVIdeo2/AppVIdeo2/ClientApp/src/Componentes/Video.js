import { useEffect } from "react"
import { transformar } from "../Helpers/Convertidor"

export const Videos = ({data }) => {

    const TransformarV = async () => {
        const traer = await transformar(data)
    }

    useEffect(() => {
        TransformarV()
    }, [])

    return(
        <>
            <div className = "CargaVideo">
                <video src={data.Url} controls ></video>
            </div>

        </>

    )
}