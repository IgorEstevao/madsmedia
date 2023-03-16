import hexRgb from "hex-rgb";

const black = "#0D0D0D";
const black2 = "#171717";
const pink = "#E80053";
const gray1 = "#565656";
const gray2 = "#C4C4C4";
const white = "#fff";

export type BaseColors = typeof black | typeof black2 | typeof pink | typeof gray1 | typeof gray2 | typeof white;

type BrandColors = {
  black: BaseColors;
  black2: BaseColors;
  pink: BaseColors;
  gray1: BaseColors;
  gray2: BaseColors;
  white: BaseColors;
};

export const baseColors: BrandColors = {
  black: black,
  black2: black2,
  pink: pink,
  gray1: gray1,
  gray2: gray2,
  white: white,
};

export const baseColorsUtil = {
  opacity: (color: BaseColors, opacity: number) => {
    const { red, green, blue } = hexRgb(color);
    return `rgba(${red}, ${green}, ${blue}, ${opacity})`;
  },
};
