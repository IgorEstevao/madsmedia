import styled from "styled-components";
import { baseColors } from "../colors/colors";
import { useEffect, useRef, useState } from "react";
import { FaCircle } from "react-icons/fa";

type BaseTagStyleProps = {
  active: boolean;
  disableTooltip: boolean;
  top: number;
  left: number;
  description: string;
};

type BaseTagProps = {
  text: string;
  description?: string;
  active: boolean;
  onClick?: (tag: string) => void;
  disableTooltip?: boolean;
};

const BaseTagStyle = styled.div<BaseTagStyleProps>`
  cursor: pointer;
  border-radius: 8px;
  width: fit-content;
  padding: 4px 8px;
  background: ${(p) => (p.active ? baseColors.gray1 : baseColors.pink)};
  transition: all 300ms;
  color: ${baseColors.white};
  position: relative;
  z-index: 1;
  display: flex;
  gap: 8px;
  align-items: center;
  :hover:after {
    opacity: ${(p) => (p.disableTooltip ? 0 : 1)};
  }
  :after {
    opacity: 0;
    content: "${(p) => p.description}";
    position: absolute;
    top: ${(p) => p.top}px;
    left: ${(p) => p.left}px;
    background: ${baseColors.gray1};
    border-radius: 8px;
    padding: 8px;
    border: ${baseColors.pink} solid 2px;
  }
`;

export const BaseTag = ({ text, active, description = text, onClick, disableTooltip }: BaseTagProps) => {
  const [tagXPosition, setXPosition] = useState(0);
  const [tagYPosition, setYPosition] = useState(0);
  const [tagHeight, setHeight] = useState(0);
  const [tagWidth, setWidth] = useState(0);
  const ref = useRef(null);
  const tagOffset = 15;

  useEffect(() => {
    setHeight((ref.current as any).clientHeight);
    setWidth((ref.current as any).clientWidth);
  }, []);

  return (
    <BaseTagStyle
      ref={ref}
      top={tagYPosition}
      left={tagXPosition}
      active={active}
      onClick={() => onClick?.(text)}
      disableTooltip={disableTooltip ?? false}
      description={description ?? ""}
      onMouseMove={(e) => {
        if (e.clientX < tagWidth) {
          setXPosition(e.clientX + tagOffset);
        }
        if (e.nativeEvent.offsetY < tagHeight) {
          setYPosition(e.nativeEvent.offsetY + tagOffset);
        }
      }}
    >
      <FaCircle fontSize={6} />
      {text}
    </BaseTagStyle>
  );
};
