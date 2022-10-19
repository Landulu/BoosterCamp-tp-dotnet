import { Link } from "react-router-dom";

import CheckIcon from "../../drawables/icons/check-icon";
import CrossIcon from "../../drawables/icons/cross-icon";

import "./form-feedback.scss";

export const FormFeedBackSucces = ({title, message, link}) => {
    return (
        <div className="form-feedback-succes">
            <div className="icon-container">
                <CheckIcon />
            </div>
            <div className="text-container">
                <h3 className="title">{title}</h3>
                <p className="message">{message}</p>
            </div>
        </div>
    )
}

export const FormFeedBackError = ({errors}) => {
    return (
        <div className="form-feedback-error">
            <div className="icon-container">
                <CrossIcon />
            </div>
            <ul className="errors-container">
                {
                    errors && errors.map((error, index) => <li key={index} className="error-text">{error}</li> )
                }
            </ul>
        </div> 
    )
}