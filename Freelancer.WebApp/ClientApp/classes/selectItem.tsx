export class SelectItem {
    private _value: string;
    private _label: string;
    private _active: boolean;

    constructor(value: string, label: string, active: boolean) {
        this._value = value;
        this._label = label;
        this._active = active;
    }

    get value(): string {
        return this._value;
    }

    set value(newValue: string) {
        this._value = newValue;
    }

    get label(): string {
        return this._label;
    }

    set label(newLabel: string) {
        this._label = newLabel;
    }

    get active(): boolean {
        return this._active;
    }

    set active(newActive: boolean) {
        this._active = newActive;
    }
}