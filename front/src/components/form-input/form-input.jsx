import './form-input.scss'

const FormInput = ({
    label,
    name,
    placeholder,
    type,
    error,
    errorText,
    register,
    registerParams
}) => {

    const getInputText = (register, name, placeholder, registerParams) => {
        return <input
            className="input"
            name={name}
            type="text"
            placeholder={placeholder}
            {...register(name, registerParams)}
        />
    }

    const getInputNumber = (register, name, placeholder, registerParams) => {
        return <input
            className="input"
            name={name}
            type="number"
            placeholder={placeholder}
            {...register(name, registerParams)}
        />
    }

    const getInputTextarea = (register, name, placeholder, registerParams) => {
        return <textarea
            className='textarea'
            name={name}
            placeholder={placeholder}
            {...register(name, registerParams)}
        />
    }

    const getInputDate = (register, name, placeholder, registerParams) => {
        return <input
            className="input"
            name={name}
            type="date"
            placeholder={placeholder}
            {...register(name, registerParams)}
        />
    }

    return (
        <div data-error={error ? true : false} className="form-input">
            <label className="label" htmlFor={name}>{label}</label>
            { type === "text" && getInputText(register, name, placeholder, registerParams) }
            { type === "number" && getInputNumber(register, name, placeholder, registerParams) }
            { type === "textarea" && getInputTextarea(register, name, placeholder, registerParams) }
            { type === "date" && getInputDate(register, name, placeholder, registerParams) }
            <span className="error-message">{errorText}</span>
        </div>
    );
}


export default FormInput; 