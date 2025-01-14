import axios from "axios";


class OffersService {

    #API_URL = "https://localhost:7201/api";

    getOffers() {

        return new Promise((resolve, reject) => {
            axios.get(`${this.#API_URL}/offers`)
            .then((response) => {
                resolve(response.data.offers)
            })
            .catch((error) => reject(error));
        })

    }

    getOfferById(id) {

        return new Promise((resolve, reject) => {
            axios.get(`${this.#API_URL}/offers/${id}`)
            .then((response) => resolve(response.data))
            .catch((error) => reject(error));
        })
    }

    createOffer(data) {
        return new Promise((resolve, reject) => {
            axios.post(`${this.#API_URL}/offers`, data)
            .then((response) => resolve(response))
            .catch((error) => reject(error.response))
        })
    }

    contactOffer(data, id) {
        return new Promise((resolve, reject) => {
            axios.post(`${this.#API_URL}/offers/${id}/contact`, data)
            .then((response) => resolve(response))
            .catch((error) => reject(error.response))
        })
    }
}



export default OffersService;