import * as React from 'react';

export interface DropDownItem {
    value: string;
    text: string;
}

export interface IDropDownProps {
    value: string;
    name?: string;
    list: Array<DropDownItem>;
    onChange: (event: any) => void;
    preselect?: string;
    className?: string;
    label?: string;
    placeholder?: string;
    error?: string;
}

const DropDown: React.StatelessComponent<IDropDownProps> = (prop: IDropDownProps) => {
    let wrapperClass = 'form-group';
    if (prop.error && prop.error.length > 0) {
        wrapperClass += " " + 'has-error';
    }
    
    return (
        <div className={wrapperClass}>
            {prop.label && <label htmlFor={name}>{prop.label}</label>}
            <div className="field">
                <select
                    className={"dropdown-control " + (prop.className ? prop.className : " ")}
                    name={prop.name}
                    value={prop.value}
                    onChange={prop.onChange}>

                    {prop.placeholder && <option key="default" value="DEFAULT">{prop.placeholder}</option>}
                    {prop.list && prop.list.map(item =>
                        <option key={item.value} value={item.value} >
                            {item.text}
                        </option>
                    )}
                </select>
                {prop.error && <div className="alert alert-danger">{prop.error}</div>}
            </div>
        </div >
    );
};

export default DropDown;

