import axios from "axios";


class OffersService {

    #API_URL = "https://app-soat-bc22-dev-fr.azurewebsites.net/api";

    constructor() {}

    getOffers() {

        return new Promise((resolve, reject) => {
            axios.get(`${this.#API_URL}/offers`)
            .then((response) => resolve(response.data.items))
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
            console.log(data)
            axios.post(`${this.#API_URL}/offers`, data)
            .then((response) => resolve(response))
            .catch((error) => reject(error.response))
        })
    }
}



export default OffersService;