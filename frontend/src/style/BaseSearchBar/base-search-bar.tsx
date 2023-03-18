import styled from "styled-components";
import { baseColors } from "../colors/colors";
import { FaSearch } from "react-icons/fa";

const BaseSearchBarStyle = styled.div`
  background: ${baseColors.black2};
  border-radius: 12px;
  padding: 8px 16px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 8px;
  cursor: pointer;
  width: 100%;
  input {
    width: 100%;
  }
`;

export const BaseSearchBar = () => {
  return (
    <BaseSearchBarStyle>
      <input type="text" placeholder="Pesquisar" />
      <div>
        <FaSearch />
      </div>
    </BaseSearchBarStyle>
  );
};
