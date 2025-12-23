import { colors } from "@/utils/colors";
import { StyleSheet } from "react-native";

export const styles = StyleSheet.create({
    container:{
        width: "100%",
        gap: 12,
    },
    title:{
        color: colors.gray[300],
        marginLeft: 20,
    },
    content:{
        gap: 12,
        paddingHorizontal: 20,
    }
})