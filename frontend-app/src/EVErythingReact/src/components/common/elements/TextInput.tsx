import * as React from 'react';

export interface ITextInputProps {
    name: string;
    value: string | number;
    onChange: (event: any) => void;
    className?: string;
    currency?: string;
    type?: string;
    label?: string;
    disabled?: boolean;
    readonly?: boolean;
    placeholder?: string;
    error?: string;
    max?: number;
    focus?: boolean;
    autoComplete?: boolean;
}

const TextInput: React.StatelessComponent<ITextInputProps> = (prop: ITextInputProps) => {

    return (
        <div className="form-group">
            <div className={"input-field " + (prop.className ? prop.className : "")}>
                {prop.label && <label htmlFor={prop.name}>{prop.label}</label>}
                <input
                    name={prop.name}
                    type={prop.type}
                    value={prop.value}
                    onChange={prop.onChange}
                    placeholder={prop.placeholder}
                    className="form-control input-box"
                    autoFocus={prop.focus}
                    autoComplete={prop.autoComplete ? "on" : "off"}
                    readOnly={prop.readonly}
                    disabled={prop.disabled}
                    maxLength={prop.max}
                />
                <span className="bar"></span>
                {prop.error && <div className="alert alert-danger">{prop.error}</div>}
            </div>
            {prop.currency && <span className="currency">{prop.currency}</span>}
        </div>
    );
};

export default TextInput;
