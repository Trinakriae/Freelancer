import * as React from 'react';
import * as DatePicker from 'react-bootstrap-date-picker';


interface Props {
    value: string
    onChange: (date: string, formattedDate: string) => any
    onClear?: () => void
    disabled?: boolean
    calendarPlacement?: string
    showClearButton?: boolean
    className?: string
}

export class CustomDatePicker extends React.Component<Props, {}> {
    constructor(props: Props) {
        super(props);

        this.onClear = this.onClear.bind(this);
    }

    onClear() {
        if (this.props.onClear) {
            this.props.onClear();
        }
    }

    render() {
        const { value, disabled, calendarPlacement, showClearButton } = this.props;

        return (
            <DatePicker
                dateFormat="DD/MM/YYYY"
                value={value}
                onChange={this.props.onChange}
                onClear={this.onClear}
                showClearButton={showClearButton ? showClearButton : true}
                showTodayButton={true}
                calendarPlacement={calendarPlacement ? calendarPlacement : 'top'}
                disabled={disabled ? disabled : false}
            />
    )}
}