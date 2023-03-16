import styled from "styled-components";
import { baseColors } from "../colors/colors";

const BaseButtonStyle = styled.button`
  height: 30px;
  border-radius: 8px;
  width: fit-content;
  padding: 16px;
  border: ${baseColors.pink} 2px solid;
  background: ${baseColors.black};
  color: ${baseColors.white};
  display: flex;
  justify-content: center;
  align-items: center;
  cursor: pointer;
  transition: all 200ms;
  :hover {
    background: ${baseColors.pink};
    color: ${baseColors.black};
  }
`;

type BaseButtonProps = {
  text: string;
  onClick?: () => void;
};

export const BaseButton = ({ text, onClick }: BaseButtonProps) => {
  return <BaseButtonStyle onClick={onClick}>{text}</BaseButtonStyle>;
};
