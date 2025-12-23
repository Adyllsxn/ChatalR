import { View, Text,TouchableOpacity, FlatList } from "react-native";
import { Feather } from "@expo/vector-icons";
import { colors } from "@/utils/colors";
import Page from "@/components/common/home/page";
import { styles } from "./styles";
import { Props } from "./type";

export default function PageList({data}: Props){
    return(
        <View style={styles.container}>
            <View style={styles.header}>
                <Text style={styles.title}>Privado</Text>

                <TouchableOpacity>
                    <Feather name="more-horizontal" size={20} color={colors.gray[300]}/>
                </TouchableOpacity>

                <TouchableOpacity>
                    <Feather name="plus" size={20} color={colors.gray[300]}/>
                </TouchableOpacity>
            </View>

            <FlatList 
                data={data}
                keyExtractor={item => item.id}
                renderItem={({item}) => <Page title={item.title}/>}
                showsVerticalScrollIndicator={false}
                style={styles.list}
                ItemSeparatorComponent={() => <View style={styles.separator}/>}
                scrollEnabled={false}/>
        </View>
    )
}