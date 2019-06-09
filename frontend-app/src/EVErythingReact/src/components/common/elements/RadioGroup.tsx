import * as React from 'react';

export interface radioListModel {
    value: string;
    group: string;
    label: string;
    description?: string;
}

export interface IRadioGroupProps {
    list: Array<radioListModel>;
    onChange: (event: any) => void;
    selectedItem: string;
    name?: string;
    className?: string;
    label?: string;
    error?: string;
    description?: string;
}

const RadioGroup: React.StatelessComponent<IRadioGroupProps> = (prop: IRadioGroupProps) => {
    return (
        <div className="form-group">

            <div className={"input-field " + (prop.className ? prop.className : "")}>
                {prop.label && <label htmlFor={prop.name}>{prop.label}</label>}

                {prop.list && prop.list.map((item, index) =>
                    <div key={index} className="radio-item">
                        <input
                            className="radio-input"
                            type="radio"
                            value={item.value}
                            name={item.group}
                            checked={prop.selectedItem === item.value}
                            onChange={prop.onChange} />

                        <span className="checkmark"></span>
                        <span className="radio-label">{item.label}</span>
                        {prop.description && <span className="radio-description">{item.description}</span>}
                    </div>
                )}

                {prop.error && <div className="alert alert-danger">{prop.error}</div>}
            </div>
        </div>
    );
};

export default RadioGroup;
