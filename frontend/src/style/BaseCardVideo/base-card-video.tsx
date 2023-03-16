import styled from "styled-components";
import { baseColors, baseColorsUtil } from "../colors/colors";
import { FaTv } from "react-icons/fa";
import { FaStar } from "react-icons/fa";
import { useState } from "react";
const BaseCardVideoStyle = styled.div`
  height: 245px;
  width: 154px;
  position: relative;
  cursor: pointer;
  display: flex;
  flex-direction: column;
  border-radius: 8px;
  border: ${baseColors.black2} 2px solid;
  transition: all 200ms;
  box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.25);
  background: ${baseColors.black2};
  img {
    height: 200px;
    width: 154px;
    border-radius: 8px 8px 0px 0px;
  }
  div {
    z-index: 1;
    transition: all 300ms;
    opacity: 0;
    position: absolute;
    width: 100%;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding-inline: 16px;
    padding-top: 8px;
    font-size: 12px;
    label {
      height: 20px;
      display: flex;
      align-items: center;
      gap: 4px;
      color: ${baseColors.white};
    }
  }
  footer {
    background: ${baseColors.black2};
    color: ${baseColors.pink};
    height: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    font-size: 0.7em;
    text-align: center;
    padding-inline: 8px;
  }
  :after {
    transition: all 200ms;
    overflow: hidden;
    opacity: 0;
    content: "";
    position: absolute;
    height: 50px;
    width: 100%;
    background-image: linear-gradient(to top, rgba(255, 0, 0, 0), ${baseColorsUtil.opacity(baseColors.black2, 0.6)});
  }
  :hover:after {
    opacity: 1;
  }
  :hover{
    transform: scale(1.05)
  }
`;

type BaseCardVideoProps = {
  title: string;
  id?: string;
  onClick?: () => void;
}

export const BaseCardVideo = ({title, onClick}: BaseCardVideoProps) => {
  const [showStatistic, setShowStatistic] = useState(false);
  return (
    <BaseCardVideoStyle onMouseEnter={() => setShowStatistic(true)} onMouseLeave={() => setShowStatistic(false)}>
      {(
        <div style={{opacity: showStatistic ? 1 : 0 }}>
          <label>
            <FaTv />
            13K
          </label>
          <label>
            <FaStar />
            420
          </label>
        </div>
      )}
      <img
        src="https://cdn.discordapp.com/attachments/473807758660075520/1074076509616214107/IncE1Jp6NFk.png"
        alt="tomboy"
      />
      <footer>{title}</footer>
    </BaseCardVideoStyle>
  );
};
